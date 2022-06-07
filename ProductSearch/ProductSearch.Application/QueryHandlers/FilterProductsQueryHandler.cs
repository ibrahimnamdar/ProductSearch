using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductSearch.Application.Dtos;
using ProductSearch.Application.Queries;
using ProductSearch.Domain.Base;
using ProductSearch.Domain.Entities;
using ProductSearch.Domain.Enums;
using ProductSearch.Infrastructure.Extensions;
using ProductSearch.Infrastructure.Repositories;

namespace ProductSearch.Application.QueryHandlers
{
    public class FilterProductsQueryHandler : IRequestHandler<FilterProductsQuery, FilterProductsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public FilterProductsQueryHandler(IMapper mapper, IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<FilterProductsResponse> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(request.Brand), x => x.Brand.ToLower().Contains(request.Brand.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.SearchQuery), x => x.Name.ToLower().Contains(request.SearchQuery.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Color), x => x.Color.ToLower().Contains(request.Color.ToLower()))
                .OrderByDescendingIf(request.OrderingType == OrderingType.HighestPrice.GetDescription(), x => x.Price)
                .OrderByIf(request.OrderingType == OrderingType.LowestPrice.GetDescription(), x => x.Price)
                .OrderByIf(request.OrderingType == OrderingType.NewestAtoZ.GetDescription(), x => x.Name)
                .OrderByDescendingIf(request.OrderingType == OrderingType.NewestZtoA.GetDescription(), x => x.Name)
                .Take(request.PageSize).Skip((request.Page - 1) * request.PageSize).ToListAsync();

            var colorFilters = await _productRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(request.Brand), x => x.Brand.ToLower().Contains(request.Brand.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.SearchQuery), x => x.Name.ToLower().Contains(request.SearchQuery.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Color), x => x.Color.ToLower().Contains(request.Color.ToLower()))
                .Select(x => x.Color).GroupBy(x => x).Select(g => new KeyAndValuePair() { Name = g.Key, Count = g.Count() }).ToListAsync();

            var brandFilters = await _productRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(request.Brand), x => x.Brand.ToLower().Contains(request.Brand.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.SearchQuery), x => x.Name.ToLower().Contains(request.SearchQuery.ToLower()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Color), x => x.Color.ToLower().Contains(request.Color.ToLower()))
                .Select(x => x.Brand).GroupBy(x => x).Select(g => new KeyAndValuePair() { Name = g.Key, Count = g.Count() }).ToListAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            var response = new FilterProductsResponse()
            {
                Products = productDtos,
                ColorFilters = colorFilters,
                BrandFilters = brandFilters
            };

            return response;
        }
    }
}