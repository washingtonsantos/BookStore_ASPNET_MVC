using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repositorio
{
    public interface IAutorRepositorio : IDisposable
    {
        List<Autor> ObterAutores();
        Autor ObterAutorPorId(int id);
        List<Autor> ObterAutorPorNome(string nome);
        bool Criar(Autor autor);
        bool Editar(Autor autor);
        void Deletar(int id);
    }
}
