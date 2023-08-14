using System.Collections.Generic;
using YoMarket.Models;

namespace YoMarket.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}