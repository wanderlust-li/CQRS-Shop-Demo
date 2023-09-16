using AutoMapper;
using ShopDemo.Application.Commands.Product;
using ShopDemo.Domain.Entities;

namespace ShopDemo.Application;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<CreateProductCommand, Product>();
        
        CreateMap<Product, CreateProductCommand>();
    }
}