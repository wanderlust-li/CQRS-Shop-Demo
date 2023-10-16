using AutoMapper;
using ShopDemo.Application.Features.Product.Commands.CreateProduct;
using ShopDemo.Application.Features.Product.Commands.UpdateProduct;
using ShopDemo.Application.Features.Product.Queries.GetAllProduct;
using ShopDemo.Application.Features.Product.Queries.GetProduct;
using ShopDemo.Domain;

namespace ShopDemo.Application.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductAllDto, Product>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}