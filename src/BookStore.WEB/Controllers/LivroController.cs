using BookStore.Domain.Interfaces.Repositorio;
using BookStore.WEB.ViewModels.Livro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BookStore.WEB.Controllers
{
    [Route("livros")]
    public class LivroController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(ILivroRepositorio livroRepositorio, ICategoriaRepositorio categoriaRepositorio)
        {
            _livroRepositorio = livroRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet("listar")]
        public IActionResult Index()
        {
            try
            {
                var livros = _livroRepositorio.ObterLivros();

                var livrosViewModels = new List<WEB.ViewModels.Livro.LivroViewModel>();

                foreach (var livro in livros)
                {
                    livrosViewModels.Add(new LivroViewModel 
                    { 
                       Id = livro.Id,
                       Nome = livro.Nome,
                       ISBN = livro.ISBN,
                       CategoriaId = livro.CategoriaId,
                       DataLancamento = livro.DataLancamento
                    });
                }

                return View(livrosViewModels);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        [HttpGet("criar")]
        public IActionResult Create()
        {
            var categorias = _categoriaRepositorio.ObterCategorias();

            var model = new LivroViewModel
            {
                Nome = string.Empty,
                ISBN = string.Empty,
                CategoriaId = 0,
                Categorias = new SelectList(categorias, "Id", "Nome")
            };

            return View(model);
        }

        [HttpGet("editar")]
        public IActionResult Edit(int id)
        {
            try
            {
                if (id == 0) return BadRequest("id do livro inválido!");

                var _livro = _livroRepositorio.ObterLivroPorId(id);
                var categorias = _categoriaRepositorio.ObterCategorias();

                var livro = new LivroViewModel
                {
                    Id = _livro.Id,
                    Nome = _livro.Nome,
                    ISBN = _livro.ISBN,
                    DataLancamento = _livro.DataLancamento,
                    CategoriaId = _livro.CategoriaId,
                    Categorias = new SelectList(categorias, "Id","Nome")
                };

                return View(livro);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor " + ex.Message);
            }

        }

        [HttpDelete("deletar/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPost("criar")]
        public IActionResult Create(LivroViewModel livroViewModel)
        {
            try
            {
                if (livroViewModel.CategoriaId == 0) return BadRequest("Escolha uma categoria");

                if (string.IsNullOrEmpty(livroViewModel.Nome)) return BadRequest("Escolha o nome do livro");

                if (livroViewModel.DataLancamento == DateTime.MinValue || livroViewModel.DataLancamento > DateTime.Now)
                    return BadRequest("Escolha uma data válida");

                var livro = new Domain.Entities.Livro
                {
                    Nome = livroViewModel.Nome,
                    ISBN = livroViewModel.ISBN,
                    DataLancamento = livroViewModel.DataLancamento,
                    CategoriaId = livroViewModel.CategoriaId
                };


                _livroRepositorio.Add(livro);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
            
        }
    }
}
