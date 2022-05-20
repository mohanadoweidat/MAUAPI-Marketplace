using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Notify
    {
        public List<UserAccount> usersWithInterest { get; set; }
        public string productType { get; set; }

        public Notify(List<UserAccount> usersWithInterest, string productType)
        {
            this.usersWithInterest = usersWithInterest;
            this.productType = productType;
        }

        
    }
}