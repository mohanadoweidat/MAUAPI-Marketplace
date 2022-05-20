using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
 
        public Cart()
        {
            Items = new List<CartItem>();
        }

         private int ItemIndexOf(Guid id)
        {
            foreach (CartItem item in Items)
            {
                if (item.Id == id)
                {
                    return Items.IndexOf(item);
                }
            }
            return -1;
        }
 
        public bool AddItemToCart(CartItem item)
        {
            int index = ItemIndexOf(item.Id);
            if (index == -1)
            {
                Items.Add(item);
                return true;
            }
            return false;
        }

        public void Delete(int rowId)
        {
            Items.RemoveAt(rowId); 
        }
        public double GrandTotal
        {
            get {
                if (Items == null)
                {
                    return 0;
                }
                else
                {
                    double grandTotal = 0;
                     
                    foreach (CartItem item in Items)
                    {
                        int price = int.Parse(item.productPrice);
                        grandTotal += price;
                    }
                    return grandTotal;
                }
            }
        }
    }
}