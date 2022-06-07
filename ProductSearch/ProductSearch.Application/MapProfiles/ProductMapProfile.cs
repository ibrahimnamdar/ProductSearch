using AutoMapper;
using ProductSearch.Application.Dtos;
using ProductSearch.Domain.Entities;

namespace ProductSearch.Application.MapProfiles
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}