using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dotnet.Onion.Template.Repository.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextApp).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            ILoggerFactory logger = LoggerFactory.Create(x => x.AddConsole());
            optionsBuilder.UseLoggerFactory(logger);

            base.OnConfiguring(optionsBuilder);
        }





    }
}
