using YoMarket.Models;
using System.Collections.Generic;

namespace YoMarket.Models
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        // Relations (Navigation Property)

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
