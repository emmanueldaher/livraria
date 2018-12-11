using Livraria.DAL.Exceptions;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.DAL
{
    public class LivroRepository : IDisposable
    {
        private readonly LivrariaDbContext Db;

        public LivroRepository(LivrariaDbContext livrariaDb)
        {
            Db = livrariaDb;
        }

        public IEnumerable<Livro> GetAllLivros()
        {
            return Db.Livros.ToArray();
        }

        public async Task<Livro> Find(int id)
        {
            return await Db.Livros.FindAsync(id);
        }

        public async Task<Livro> FindByISBN(string isbn)
        {
            return await Db.Livros.FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<Livro> Insert(Livro livro)
        {
            if (await FindByISBN(livro.ISBN) != null)
            {
                throw new ISBNExistenteException(livro.ISBN);
            }

            Db.Livros.Add(livro);
            await Db.SaveChangesAsync();

            return livro;
        }

        public async Task Update(Livro livro)
        {
            Db.Entry(livro).State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task Remove(Livro livro)
        {
            Db.Livros.Remove(livro);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
