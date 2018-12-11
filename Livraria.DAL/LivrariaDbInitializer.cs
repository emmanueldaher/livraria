using Livraria.Models;
using SQLite.CodeFirst;
using System;
using System.Data.Entity;

namespace Livraria.DAL
{
    public class LivrariaDbInitializer : SqliteDropCreateDatabaseAlways<LivrariaDbContext>
    {
        public LivrariaDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }

        //protected override void Seed(LivrariaDbContext context)
        //{
        //    context.Set<Livro>().Add(new Livro()
        //    {
        //        ISBN = "9788532511010",
        //        Nome = "Harry Potter e A Pedra Filosofal",
        //        Autor = "J. K. Rowling",
        //        Publicacao = new DateTime(2000, 1, 1),
        //        Preco = 38.5,
        //        CapaImg = "https://images.livrariasaraiva.com.br/imagemnet/imagem.aspx/?pro_id=443852&qld=90&l=430"
        //    });

        //    context.SaveChanges();
        //}
    }
}