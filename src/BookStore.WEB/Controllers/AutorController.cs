using Microsoft.AspNetCore.Mvc;

namespace BookStore.WEB.Controllers
{
    [Route("autores")]
    public class AutorController : Controller
    {
        [Route("listar")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("criar")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("editar/{id:int:min(1)}")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [Route("excluir/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
