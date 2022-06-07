using MediatR;
using ProductSearch.Application.Dtos;

namespace ProductSearch.Application.Queries;

public class FilterProductsQuery : IRequest<FilterProductsResponse>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string SearchQuery { get; set; }
    public string OrderingType { get; set; }
}