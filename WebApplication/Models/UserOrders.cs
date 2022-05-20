using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UserOrders
    {
        public List<OrderItem> Items { get; set; }
        public Guid Id { get; set; }

        public string OrderStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public string BuyerName { get; set; }

        public UserOrders(string BuyerName)
        {
            Items = new List<OrderItem>();
            Id = Guid.NewGuid();
            OrderStatus = "Pending";
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            OrderDate = dt;
            this.BuyerName = BuyerName;
        }

        //Add an item (Product)  to the order
        public bool AddItemToOrder(OrderItem item)
        {
            int index = Items.IndexOf(item);
            if (index == -1)
            {
                Items.Add(item);
                return true;
            }
            return false;
        }

         
        //Count order total price.
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
                     
                    foreach (OrderItem item in Items)
                    {
                        int price = int.Parse(item.ProductPrice);
                        grandTotal += price;
                    }
                    return grandTotal;
                }
            }
        }
    }
}