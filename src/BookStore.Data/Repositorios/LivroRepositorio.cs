using BookStore.Data.Contexto;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        BookStoreContexto _db;
        public LivroRepositorio(BookStoreContexto contexto)
        {
            _db = contexto;
        }

        public long Add(Livro livro)
        {
            _db.Livros.Add(livro);
            return _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Livro ObterLivroPorId(int id)
        {
            return _db.Livros.Find(id);
        }

        public IEnumerable<Livro> ObterLivros()
        {
            return _db.Livros.ToList();
        }

        public bool Update(Livro livro)
        {
            throw new System.NotImplementedException();
        }
    }
}
