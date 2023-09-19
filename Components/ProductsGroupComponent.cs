using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Data;

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
            return View("/Views/Components/ProductViewComponent.cshtml", _context.Categories);
        }
    }
}
