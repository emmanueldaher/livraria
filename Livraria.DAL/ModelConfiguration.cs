using Livraria.Models;
using System.Data.Entity;

namespace Livraria.DAL
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfiguraLivroEntity(modelBuilder);
        }

        private static void ConfiguraLivroEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .ToTable("livros")
                .HasKey(l => l.Id);
        }

    }
}