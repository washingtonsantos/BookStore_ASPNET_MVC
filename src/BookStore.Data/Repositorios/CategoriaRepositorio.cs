using BookStore.Data.Contexto;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        BookStoreContexto _db;

        public CategoriaRepositorio(BookStoreContexto contexto)
        {
            _db = contexto;
        }

        public Categoria Add(Categoria categoria)
        {
            var novaCategoria = _db.Add(categoria);

            if (novaCategoria != null)
            {
                var id = _db.SaveChanges();
                return _db.Find<Categoria>(categoria.Id);
            }

            return null;
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            return _db.Find<Categoria>(id);
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _db.Categorias.ToList();
        }
    }
}
