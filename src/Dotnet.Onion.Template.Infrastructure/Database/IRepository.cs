using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotnet.Onion.Template.Crosscutting.Specification;
using Microsoft.EntityFrameworkCore.Storage;

/*
 * Repository: Mediates between the domain and data mapping layers 
 * using a collection-like interface for accessing domain objects. 
 * https://martinfowler.com/eaaCatalog/repository.html
 * 
 * This is a generic interface for repositories to be used
 */

namespace Dotnet.Onion.Template.Infrastructure.Database
{
    public interface IRepository<TEntity>
    {
    
        Task Save(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> Get(object id);
        Task<IEnumerable<TEntity>> GetAllByCriteria(ISpecification<TEntity> specification);
        Task<TEntity> GetOneByCriteria(ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IDbContextTransaction> CreateTransaction();
        Task<IDbContextTransaction> CreateTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.Serializable);
        Task<IEnumerable<TEntity>> GetAllByCriteria(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetOneByCriteria(Expression<Func<TEntity, bool>> expression);
    }
}
