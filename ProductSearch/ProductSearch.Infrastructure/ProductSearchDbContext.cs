using Microsoft.EntityFrameworkCore;
using ProductSearch.Domain.Entities;

namespace ProductSearch.Infrastructure;

public class ProductSearchDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductSearchDbContext(DbContextOptions<ProductSearchDbContext> options) : base(options)
    {
    }
}