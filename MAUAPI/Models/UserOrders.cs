using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAUAPI.Models
{
    public class UserOrders
    {
        public class OrderItem
        {

            [Key]
            public Guid ProductId { get; set; }
            public string? ProductName { get; set; }
            public string? ProductPrice { get; set; }
            public string? SellerName { get; set; }
            public Guid OrderId { get; set; }
        }

        [Key]
        public Guid Id { get; set; }
        public string? OrderStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public string? BuyerName { get; set; }

        public IEnumerable<OrderItem>? Items { get; set; }
    }
}
