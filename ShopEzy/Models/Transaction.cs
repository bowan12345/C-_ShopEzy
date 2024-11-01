using System.ComponentModel.DataAnnotations;

namespace ShopEzy.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public Transaction()
        {
        }

        public Transaction(int customerId, int productId,string productName, int quantity, decimal price, DateTime date)
        {
            CustomerId = customerId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Date = date;
        }

        public override string ToString()
        {
            return $"Transaction Id: {Id}, Customer Id: {CustomerId}, Product Id: {ProductId}, Product Name: {ProductName}, Quantity: {Quantity}, Price: {Price}, Date: {Date}";
        }
    }
}
