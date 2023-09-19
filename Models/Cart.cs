using System.Collections.Generic;
using System.Linq;

namespace YoMarket.Models
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int OrderId { get; set; }
        public List<CartItem> CartItems { get; set; }
        
        // Add And Remove To Cart
        public void additem(CartItem item)
        {
            if (CartItems.Exists(i=> i.Item.Id == item.Item.Id))
            {
                CartItems.Find(i => i.Item.Id == item.Item.Id).Quantity += 1;
            }
            else
            {
                CartItems.Add(item);
            }
        }

        public void removeitem(int itemid)
        {
            var item = CartItems.SingleOrDefault(x=>x.Item.Id == itemid);
            if (item?.Quantity<=1)
            {
                CartItems.Remove(item);
            }
            else if (item != null)
            {
                item.Quantity -= 1;
            }
        }
    }
}