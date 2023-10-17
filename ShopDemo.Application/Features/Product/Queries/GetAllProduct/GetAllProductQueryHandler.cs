using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.Logging;
using ShopDemo.Application.Contracts.ProductRepository;

namespace ShopDemo.Application.Features.Product.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductAllDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<GetAllProductQueryHandler> _logger;

    public GetAllProductQueryHandler(IMapper mapper, IProductRepository productRepository,
        IAppLogger<GetAllProductQueryHandler> logger)
    {
        this._mapper = mapper;
        this._productRepository = productRepository;
        this._logger = logger;
    }

    public async Task<List<ProductAllDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAsync();

        var data = _mapper.Map<List<ProductAllDto>>(products);
        
        _logger.LogInformation("Product were retrieved successfully");

        return data;
    }
}