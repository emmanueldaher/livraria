using System;

namespace Livraria.DAL.Exceptions
{
    public class ISBNExistenteException : Exception
    {
        public readonly string ISBN;

        public ISBNExistenteException(string isbn) 
            : base($"Já existe um livro com o seguinte ISBN cadastrado, {isbn}.")
        {
            ISBN = isbn;
        }
    }
}