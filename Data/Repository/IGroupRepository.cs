using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Models;

namespace YoMarket.Data.Repository
{
    public interface IGroupRepository
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowsGroupViewModel> GetGroupForShow();

        
    }
    public class GroupRepository : IGroupRepository
    {
        private EshopContext _context;
        public GroupRepository(EshopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShowsGroupViewModel> GetGroupForShow()
        {
            return _context.Categories
                .Select(c => new ShowsGroupViewModel()
                {
                    GroupId = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }
}
