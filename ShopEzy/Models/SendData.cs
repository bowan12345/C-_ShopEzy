using Microsoft.EntityFrameworkCore;
using ShopEzy.Data;

namespace ShopEzy.Models
{
    public class SendData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Code to initialize the SendData class}
            using (var context = new ShopEzyDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ShopEzyDbContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }
                context.Product.AddRange(
                    new Product
                    {
                        Name = "Lucky Cookie",
                        Description = " A chocolate chip cookie with a hint of vanilla and a dash of nuts.",
                        Price = 15.99M
                    },
                    new Product
                    {
                        Name = "Instant Noodle",
                        Description = " A noodle soup that takes less than 10 minutes to cook.",
                        Price = 19.99M
                    },
                    new Product
                    {
                        Name = "Chocolate Chip Cookies",
                        Description = " A chocolate chip cookie with a hint of vanilla and a dash of nuts.",
                        Price = 16.99M
                    },
                    new Product
                    {
                        Name = " Bear Candy",
                        Description = " A candy that is made with honey and bear's urine.",
                        Price = 9.99M
                    },
                    new Product
                    {
                        Name = "Ghost Wine",
                        Description = " A wine made from the remains of a dead horse.",
                        Price = 15.99M
                    },
                    new Product
                    {
                        Name = " Fuji Apple",
                        Description = " An apple that grows on trees and has a juicy skin.",
                        Price = 22.99M
                    }

                );
                context.SaveChanges();


            }

        }
    }
}
