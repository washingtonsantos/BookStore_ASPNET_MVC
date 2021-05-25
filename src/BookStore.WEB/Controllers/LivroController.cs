using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WEB.Controllers
{
    [Route("livros")]
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("criar")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
