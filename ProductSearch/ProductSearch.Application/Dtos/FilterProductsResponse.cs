using ProductSearch.Domain.Base;

namespace ProductSearch.Application.Dtos;

public class FilterProductsResponse
{
    public List<ProductDto> Products { get; set; }
    public List<KeyAndValuePair> ColorFilters { get; set; }
    public List<KeyAndValuePair> BrandFilters { get; set; }
}