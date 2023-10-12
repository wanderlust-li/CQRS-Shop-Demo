using AutoMapper;
using ShopDemo.Application.Features.Product.Queries.GetAllProduct;
using ShopDemo.Domain;

namespace ShopDemo.Application.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>().ReverseMap();
    }
}