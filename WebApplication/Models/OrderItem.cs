using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string SellerName { get; set; }
        public Guid OrderId { get; set; }


        public OrderItem()
        {

        }
 
        public OrderItem(Guid productId, Guid orderId, string productName, string productPrice, string sellerName)
        {
            ProductId = productId;
            OrderId = orderId;
            ProductName = productName;
            ProductPrice = productPrice;
            SellerName = sellerName;
        }
    }
}