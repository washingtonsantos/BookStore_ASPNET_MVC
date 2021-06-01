using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repositorio
{
    public interface ILivroRepositorio
    {
        IEnumerable<Entities.Livro> ObterLivros();
        Entities.Livro ObterLivroPorId(int id);
        long Add(Entities.Livro livro);
        bool Update(Entities.Livro livro);
        void Delete(int id);
    }
}
