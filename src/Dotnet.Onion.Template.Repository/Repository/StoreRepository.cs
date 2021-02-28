using System;
using Dapper;
using Dotnet.Onion.Template.Domain.Store;
using Dotnet.Onion.Template.Domain.Store.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Dotnet.Onion.Template.Repository.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly string _connectionString;
        private readonly IDistributedCache _redisCache;
        private const string KeyAllStores = "ALL_STORES";

        public StoreRepository(IOptions<DatabaseOptions> options, IDistributedCache redisCache)
        {
            _redisCache = redisCache;
            _connectionString = options.Value.DefaultConnectionString;
        }

        public async Task<IEnumerable<Store>> FindAll()
        {
            var dataCache = await _redisCache.GetStringAsync(KeyAllStores);
            if (string.IsNullOrWhiteSpace(dataCache))
            {
                var cacheSettings = new DistributedCacheEntryOptions();
                cacheSettings.SetAbsoluteExpiration(TimeSpan.FromMinutes(20));
                
                await using var connection = new SqlConnection(_connectionString);
                var stores = await connection.QueryAsync<Store>(StoreQuery.FindAll());

                var itemsJson = JsonConvert.SerializeObject(stores);
                await _redisCache.SetStringAsync(KeyAllStores, itemsJson, cacheSettings);
                return stores;
            }

            var storesFromCache = JsonConvert.DeserializeObject<IEnumerable<Store>>(dataCache);
            return await Task.FromResult(storesFromCache);
        }


        public async Task<Store> FindById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var store = await connection.QueryFirstAsync<Store>(StoreQuery.FindById(), new { id });
            return store;
        }
    }
}
