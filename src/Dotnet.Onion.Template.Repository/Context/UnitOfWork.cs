using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dotnet.Onion.Templante.Crosscutting.Entity;
using Dotnet.Onion.Template.Crosscutting.Entity;
using Dotnet.Onion.Template.Crosscutting.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet.Onion.Template.Repository.Context
{
    public class UnitOfWork<TDomain> where TDomain: class, IDomain<TDomain>
    {
        public DbSet<TDomain> Query { get; set; }
        public DbContext Context { get; set; }

        public UnitOfWork(ContextApp context)
        {
            this.Context = context;
            this.Query = context.Set<TDomain>();
        }


        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await this.Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CreateTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.Serializable)
        {
            return await this.Context.Database.BeginTransactionAsync(isolation);
        }

        public async Task Delete(TDomain entity)
        {
            this.Query.Remove(entity);
            await this.Context.SaveChangesAsync();
            
        }

        public async Task Save(TDomain entity)
        {
            await this.Query.AddAsync(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task Update(TDomain entity)
        {
            this.Query.Update(entity);
            await this.Context.SaveChangesAsync();

        }

        public async Task<TDomain> Get(object id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task<IEnumerable<TDomain>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<IEnumerable<TDomain>> GetAllByCriteria(ISpecification<TDomain> specification)
        {
            return await Task.FromResult(this.Query.Where(specification.SatisfyByCriteria()).AsEnumerable());
        }

        public async Task<TDomain> GetOneByCriteria(ISpecification<TDomain> specification)
        {
            return await this.Query.Where(specification.SatisfyByCriteria()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TDomain>> GetAllByCriteria(Expression<Func<TDomain, bool>> expression)
        {
            return await Task.FromResult(this.Query.Where(expression).AsEnumerable());
        }

        public async Task<TDomain> GetOneByCriteria(Expression<Func<TDomain, bool>> expression)
        {
            return await this.Query.Where(expression).FirstOrDefaultAsync();
        }

    }
}
