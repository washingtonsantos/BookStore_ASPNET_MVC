using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WEB.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorRepositorio _autorRepositorio;
        public AutorController(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        public IActionResult Index()
        {
            var autores = _autorRepositorio.ObterAutores();
            return View(autores);
        }


        [HttpGet("criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("criar")]
        public IActionResult Create(Autor autor)
        {
            _autorRepositorio.Criar(autor);
            return View();
        }

        [HttpPost("editar/{id:int:min(1)}")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost("excluir/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
