using ProductSearch.Domain.Base;

namespace ProductSearch.Domain.Entities;

public class Product : IEntity
{
    public int Id { get; set; }

    /// <summary>
    /// Hosted image url of product
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Related brand
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Color of product
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Base price of product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Assigned discount rate
    /// </summary>
    public int DiscountRate { get; set; }
}