using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult AddToCart(int Id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == Id);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var order = _context.Order.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail = _context.OrderDeatail.FirstOrDefault(d => d.OrderId == order.OrderId && d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDeatail.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1,
                        });
                    }
                    _context.SaveChanges();
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreatedDate = DateTime.Now,
                        UserId = userId
                    };
                    _context.Order.Add(order);
                    
                    _context.OrderDeatail.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ShowCart");
        }
        public IActionResult RemoveCart(int DetailId)
        {
            var orderDetail = _context.OrderDeatail.Find(DetailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }
        [Authorize]
        public IActionResult ShowCart()
        {
           int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _context.Order.Where(o => o.UserId == userId && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(p => p.Product).FirstOrDefault();
            return View(order);
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
