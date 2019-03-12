using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;

namespace Edura.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;

        public HomeController(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View(repository.Products);
        }
    }
}