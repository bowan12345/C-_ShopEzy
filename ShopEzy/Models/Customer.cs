using System.ComponentModel.DataAnnotations;

namespace ShopEzy.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, string address, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Address = address;
            Password = password;
        }
        
        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} - {Email} - {PhoneNumber} - {DateOfBirth} - {Address}";
        }
    }
}
