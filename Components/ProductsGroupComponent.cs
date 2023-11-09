using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Data;
using YoMarket.Data.Repository;
using YoMarket.Models;

namespace YoMarket.Components
{
    public class ProductsGroupComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductsGroupComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/ProductViewComponent.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
