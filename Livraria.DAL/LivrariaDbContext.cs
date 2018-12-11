using Livraria.Models;
using SQLite.CodeFirst;
using System.Data.Common;
using System.Data.Entity;

namespace Livraria.DAL
{
    public class LivrariaDbContext: DbContext
    {
        public LivrariaDbContext() :base("LivrariaDb") {
            Configure();
        }

        public LivrariaDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public LivrariaDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new LivrariaDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
            //Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<LivrariaDbContext>());

        }


        public DbSet<Livro> Livros { get; set; }
    }
}