using Livraria.DAL;
using Livraria.DAL.Exceptions;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Livraria.Controllers
{
    public class LivrosController : ApiController
    {
        private LivroRepository livroRepository = new LivroRepository(new LivrariaDbContext());

        // GET: api/Livros
        public IEnumerable<Livro> GetLivroes()
        {
            return livroRepository.GetAllLivros();
        }

        // GET: api/Livros/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> GetLivro(int id)
        {
            Livro livro = await livroRepository.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/Livros/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.Id)
            {
                return BadRequest();
            }            

            try
            {
                await livroRepository.Update(livro);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Livros
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                livro = await livroRepository.Insert(livro);
            }
            catch (ISBNExistenteException e)
            {
                ModelState.AddModelError("ISBN", e);

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                throw e;
            }

            return CreatedAtRoute("DefaultApi", new { id = livro.Id }, livro);
        }

        // DELETE: api/Livros/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> DeleteLivro(int id)
        {
            Livro livro = await livroRepository.Find(id);
            if (livro == null)
            {
                return NotFound();
            }

            await livroRepository.Remove(livro);

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                livroRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<bool> LivroExists(int id)
        {
            var livro = await livroRepository.Find(id);

            return livro != null;
        }
    }
}