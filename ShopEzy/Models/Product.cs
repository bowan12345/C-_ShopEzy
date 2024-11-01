using System.ComponentModel.DataAnnotations;

namespace ShopEzy.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Price: {Price}";
        }
    }
}
