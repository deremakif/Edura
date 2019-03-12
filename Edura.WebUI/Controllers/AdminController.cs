using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Models;

namespace Edura.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IUnitOfWork unitofWork;

        public AdminController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CatalogList()
        {
            var model = new CatalogListModel()
            {
                Categories = unitofWork.Categories.GetAll().ToList(),
                Products = unitofWork.Products.GetAll().ToList()
            };

            return View(model);
        }
    }
}