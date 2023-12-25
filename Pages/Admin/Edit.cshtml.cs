using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Pages.Admin
{
    public class EditModel : PageModel
    {
        private EshopContext _context;

        public EditModel(EshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet(int id)
        {
            var product = _context.Products.Include(p => p.Item)
                 .Where(p => p.Id == id)
                 .Select(s => new AddEditProductViewModel()
                 {
                     Id = s.Id,
                     ProductName = s.Name,
                     ProductDescription = s.Description,
                     QuantityInStock = s.Item.QuantityInStock,
                     Price = s.Item.Price,
                 }).FirstOrDefault();
            Product = product;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = _context.Products.Find(Product.Id);
            var item = _context.Item.First(p => p.Id == product.ItemId);
            product.Name = Product.ProductName;
            product.Description = Product.ProductDescription;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QuantityInStock;

            _context.SaveChanges();
            if (Product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);

                }
            }
            return RedirectToPage("Index");
        }
    }
}
