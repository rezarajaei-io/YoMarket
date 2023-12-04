using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private EshopContext _context;
        public IndexModel(EshopContext context)
        {
          _context = context;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item);
        }

        public void OnPost()
        {

        }
    }
}
