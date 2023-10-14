using MediatR;

namespace ShopDemo.Application.Features.Product.Queries.GetProduct;

public record GetProductQuery(int Id) : IRequest<ProductDto>;