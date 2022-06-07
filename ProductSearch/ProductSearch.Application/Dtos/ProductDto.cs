using ProductSearch.Domain.Base;

namespace ProductSearch.Application.Dtos;

public class ProductDto
{
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
    
    public List<KeyAndValuePair> ColorFilters { get; set; }
    public List<KeyAndValuePair> BrandFilters { get; set; }
}