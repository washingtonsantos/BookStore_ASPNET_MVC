using BookStore.Data.Contexto;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly BookStoreContexto _db;
        public AutorRepositorio(BookStoreContexto context)
        {
            _db = context;
        }

        public bool Criar(Autor autor)
        {
            var novoAutor = _db.Add(autor);

            if (novoAutor != null)
               return _db.SaveChanges() > 0;

            return false;
        }

        public void Deletar(int id)
        {
            var autor = _db.Find<Autor>(id);
            _db.Remove(autor);

            _db.SaveChanges();
        }
     
        public bool Editar(Autor autor)
        {
            _db.Entry<Autor>(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _db.SaveChanges() > 0;
        }

        public List<Autor> ObterAutores()
        {
            return _db.Autores.ToList();
        }

        public Autor ObterAutorPorId(int id)
        {
            return _db.Find<Autor>(id);
        }

        public List<Autor> ObterAutorPorNome(string nome)
        {
            return _db.Autores.Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
