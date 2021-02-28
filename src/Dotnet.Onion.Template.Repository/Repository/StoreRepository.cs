using Dapper;
using Dotnet.Onion.Template.Domain.Store;
using Dotnet.Onion.Template.Domain.Store.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotnet.Onion.Template.Repository.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly string _connectionString;
        
        public StoreRepository(IOptions<DatabaseOptions> options)
        {
            _connectionString = options.Value.DefaultConnectionString;
        }

        public async Task<IEnumerable<Store>> FindAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            var stores = await connection.QueryAsync<Store>(StoreQuery.FindById());
            return stores;
        }


        public async Task<Store> FindById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            var store = await connection.QueryFirstAsync<Store>(StoreQuery.FindById(), new { id });
            return store;
        }
    }
}
