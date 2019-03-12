using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Edura.WebUI.Repository.Abstract;
using Edura.WebUI.Models;
using Edura.WebUI.Infrastructure;

namespace Edura.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult AddToCart(int ProductId, int quantity = 1)
        {
            var product = repository.Get(ProductId);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int ProductId)
        {
            var product = repository.Get(ProductId);

            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJSon<Cart>("Cart") ?? new Cart();
        }
        
    }
}