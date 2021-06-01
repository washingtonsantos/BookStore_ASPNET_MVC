using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repositorio
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<Entities.Categoria> ObterCategorias();
        Entities.Categoria ObterCategoriaPorId(int id);
        Entities.Categoria Add(Entities.Categoria categoria);
    }
}
