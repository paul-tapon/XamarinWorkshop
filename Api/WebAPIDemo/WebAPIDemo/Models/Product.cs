using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ProductNumber { get; set; }
        public decimal UnitPrice { get; set; }

        public int Quanity{ get; set; }

    }
}