using System.Collections.Generic;
using Projects.Models;

namespace YoMarket.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem> CartItems { get; set; }
        public decimal Order { get; set; }
    }
}