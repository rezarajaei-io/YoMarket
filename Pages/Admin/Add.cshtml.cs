using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Pages.Admin
{

    public class AddModel : PageModel
    {
        private EshopContext _context;
        public AddModel(EshopContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost() 
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QuantityInStock,

            };

            _context.Add(item);
            _context.SaveChanges();

            var product = new Product()
            {
                Name = Product.ProductName,
                Item = item,
                Description = Product.ProductDescription,
            };
            _context.Add(product);
            _context.SaveChanges();
            product.ItemId = product.Id;
            _context.SaveChanges();

            if (Product.Picture?.Length > 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                using(var stream = new FileStream(filepath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);

                }
            }
            return RedirectToPage("Index");
        }
    }
}
