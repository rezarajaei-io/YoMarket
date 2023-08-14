using System.Collections.Generic;
using YoMarket.Models;

namespace YoMarket.Models
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Price  { get; set; }
        public int QuantityInStock { get; set; }


        public Product Product { get; set; } // Navigation


    }
}