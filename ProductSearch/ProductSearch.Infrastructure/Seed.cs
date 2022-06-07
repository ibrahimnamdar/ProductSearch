using ProductSearch.Domain.Entities;

namespace ProductSearch.Infrastructure;

public class Seed
{
    public static void Run(ProductSearchDbContext? context)
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>();

            for (int i = 0; i < 4; i++)
            {
                products.Add(new Product()
                {
                    Brand = "Huawei",
                    Color = "Siyah",
                    Name = "Mate 40 Pro",
                    Price = 120,
                    DiscountRate = 12,
                    ImageUrl = "image2.png"
                });
            }

            for (int i = 0; i < 4; i++)
            {
                products.Add(new Product()
                {
                    Brand = "Apple",
                    Color = "Mavi",
                    Name = "IPhone 12",
                    Price = 900,
                    DiscountRate = 10,
                    ImageUrl = "image.png"
                });
            }

            for (int i = 0; i < 4; i++)
            {
                products.Add(new Product()
                {
                    Brand = "Xiaomi",
                    Color = "Beyaz",
                    Name = "10T Pro",
                    Price = 300,
                    DiscountRate = 25,
                    ImageUrl = "image3.png"
                });
            }

            context.AddRange(products);
            context.SaveChanges();
        }
    }
}