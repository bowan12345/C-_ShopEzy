using Microsoft.EntityFrameworkCore;
using ShopEzy.Models;

namespace ShopEzy.Data
{
    public class ShopEzyDbContext: DbContext
    {
        public ShopEzyDbContext(DbContextOptions<ShopEzyDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Transaction> Transaction { get; set; }


    
    }
}
