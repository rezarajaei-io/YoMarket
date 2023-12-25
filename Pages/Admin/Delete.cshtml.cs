using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private EshopContext _context;

        public DeleteModel(EshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet(int id)
        {
             Product = _context.Products.FirstOrDefault(p => p.Id == id);

        }
        public IActionResult Onpost()
        {
            var product = _context.Products.Find(Product.Id);
            var item = _context.Item.First(p => p.Id == product.ItemId);
            _context.Item.Remove(item);
            _context.Products.Remove(product);

            _context.SaveChanges();
            string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + ".jpg");
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            return RedirectToPage("Index");
        }

    }
}
