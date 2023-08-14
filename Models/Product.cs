using System.Collections.Generic;
using YoMarket.Models;

namespace YoMarket.Models
{
    public class Product
    {
     
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; } // Forigen Key
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public Item Item { get; set; } // Relation


    }
}