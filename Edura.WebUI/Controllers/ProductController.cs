using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using Edura.WebUI.Models;

namespace Edura.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(repository
                .GetAll()
                .Where(i => i.ProductId == id)
                .Include(i => i.Images)
                .Include(i => i.Attributes)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .Select(i => new ProductDetailsModel()
                {
                    Product = i,
                    ProductImages = i.Images,
                    ProductAttributes = i.Attributes,
                    Categories = i.ProductCategories.Select(a => a.Category).ToList()
                })
                .FirstOrDefault());
        }
    }
}