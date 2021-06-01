using BookStore.Domain.Interfaces.Repositorio;
using BookStore.WEB.ViewModels.Categoria;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.WEB.Controllers
{
    [Route("categoria")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public ViewResult Index()
        {
            try
            {
                var categorias = _categoriaRepositorio.ObterCategorias();
                var _categorias = new List<ViewModels.Categoria.CategoriaViewModel>();

                foreach (var categoria in categorias)
                {
                    _categorias.Add(new CategoriaViewModel { Id = categoria.Id, Nome = categoria.Nome });
                }

                return View(_categorias);
            }
            catch (System.Exception ex)
            {
                return null;
            }
            
        }

        [HttpGet("novo")]
        public IActionResult Create()
        {
            var categoria = new CategoriaViewModel();
            return View(categoria);
        }

        [HttpPost("novo")]
        public IActionResult Create([FromForm]CategoriaViewModel categoriaViewModel)
        {
            try
            {
                var categoria = new Domain.Entities.Categoria { Nome = categoriaViewModel.Nome };

                if (_categoriaRepositorio.Add(categoria) != null)
                {
                    var categorias = BuscarCategorias();
                    return View("Index", categorias);
                }

                return View();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        [HttpGet("editar/{id}")]
        public IActionResult Edit(int id)
        {
            try
            {
                var categoria = _categoriaRepositorio.ObterCategoriaPorId(id);

                var categoriaViewModel = new CategoriaViewModel { Id = categoria.Id, Nome = categoria.Nome };

                return View(categoriaViewModel);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        private List<CategoriaViewModel> BuscarCategorias()
        {
            try
            {
                var categorias = _categoriaRepositorio.ObterCategorias();
                var _categorias = new List<ViewModels.Categoria.CategoriaViewModel>();

                foreach (var categoria in categorias)
                {
                    _categorias.Add(new CategoriaViewModel { Id = categoria.Id, Nome = categoria.Nome });
                }

                return _categorias;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}
