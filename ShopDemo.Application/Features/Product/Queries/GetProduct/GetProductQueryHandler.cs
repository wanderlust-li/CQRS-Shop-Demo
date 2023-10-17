using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Application.Exceptions;

namespace ShopDemo.Application.Features.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new NotFoundException(nameof(Domain.Product), request.Id);
        }

        var data = _mapper.Map<ProductDto>(product);

        return data;
    }
}