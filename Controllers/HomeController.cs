using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EshopContext _context;
        private static Cart _cart = new Cart();
        public HomeController(ILogger<HomeController> logger, EshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            // With This We Can Show Categories in Our Detail View
            var categories = _context.Products.Where(k => k.Id == id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(cat => cat.Category)
                .ToList();

            var vm = new DetailViewModel()
            {
                Product = product,
                Categories = categories
            };
            return View(vm);
        }
        public IActionResult AddToCart(int Id)
        {
            var product = _context.Products.Include(p=>p.Item).SingleOrDefault(p => p.ItemId == Id);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity =1
                };
                _cart.additem(cartItem);

            }
            return RedirectToAction("ShowCart");
        }
        public IActionResult RemoveCart(int Id)
        {
            _cart.removeitem(Id);
            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            var CartVM = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                Order = _cart.CartItems.Sum(c => c.GetTotalPrice())
            };
            return View(CartVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
