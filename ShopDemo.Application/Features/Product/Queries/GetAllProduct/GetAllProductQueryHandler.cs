using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;

namespace ShopDemo.Application.Features.Product.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync();

        var data = _mapper.Map<List<ProductDto>>(products);

        return data;
    }
}