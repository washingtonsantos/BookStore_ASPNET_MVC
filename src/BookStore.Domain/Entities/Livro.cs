using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Livro
    {
        public Livro()
        {
            this.Autores = new List<Autor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string ISBN { get; set; }
        public DateTime DataLancamento { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }
    }
}
