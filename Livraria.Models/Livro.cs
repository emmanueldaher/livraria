using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [MinLength(13)]
        [MaxLength(13)]
        public string ISBN { get; set; }
        
        [Required]
        public string Autor { get; set; }

        [Required]
        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime Publicacao { get; set; }

        public string CapaImg { get; set; }
    }
}