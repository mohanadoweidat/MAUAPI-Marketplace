using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }


        public string ProductName { get; set; }

        public string productPrice { get; set; }

        public int? ProductYearOfMake { get; set; }

        public string ProductColour { get; set; }

        public string ProductCondition { get; set; }

        public String ProductOwner { get; set; }

        public CartItem()
        {
             
        }

        public CartItem(Guid id, string productName, string productPrice, int? productYearOfMake, string productColour, string productCondition, string productOwner)
        {
            Id = id;
            ProductName = productName;
            this.productPrice = productPrice;
            ProductYearOfMake = productYearOfMake;
            ProductColour = productColour;
            ProductCondition = productCondition;
            ProductOwner = productOwner;
        }

      
    }
}