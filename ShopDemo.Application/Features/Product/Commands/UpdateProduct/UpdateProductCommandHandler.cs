using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;

namespace ShopDemo.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = _mapper.Map<Domain.Product>(request);

        await _productRepository.UpdateAsync(productToUpdate);
        
        return Unit.Value;
    }
}