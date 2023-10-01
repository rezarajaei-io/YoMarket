using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Data;
using YoMarket.Models;

namespace YoMarket.Components
{
    public class ProductsGroupComponent : ViewComponent
    {
        private EshopContext _context;

        public ProductsGroupComponent(EshopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _context.Categories
                .Select(c => new ShowsGroupViewModel()
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
            return View("/Views/Components/ProductViewComponent.cshtml", categories);
        }
    }
}
