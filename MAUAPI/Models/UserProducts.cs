namespace MAUAPI.Models
{
    public class UserProducts
    {
        public Guid Id { get; set; }

        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? productPrice { get; set; }

        public int? ProductYearOfMake{ get; set; }

        public string? ProductColour { get; set; }

        public string? ProductCondition { get; set; }

        public string? productStatus { get; set; }

        public String? ProductOwner { get; set; }
 
    }
}
