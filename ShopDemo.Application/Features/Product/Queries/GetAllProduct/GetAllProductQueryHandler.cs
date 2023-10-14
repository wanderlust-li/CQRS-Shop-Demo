using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;

namespace ShopDemo.Application.Features.Product.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductAllDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllProductQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
    }

    public async Task<List<ProductAllDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync();

        var data = _mapper.Map<List<ProductAllDto>>(products);

        return data;
    }
}