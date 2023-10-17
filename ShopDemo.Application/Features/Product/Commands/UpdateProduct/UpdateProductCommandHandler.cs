using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.Logging;
using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Application.Exceptions;

namespace ShopDemo.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<UpdateProductCommand> _logger;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository,
        IAppLogger<UpdateProductCommand> logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        this._logger = logger;
    }
    
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator(_productRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(Domain.Product), request.Id);
            throw new BadRequestException("Invalid Product", validationResult);
        }
        
        var productToUpdate = _mapper.Map<Domain.Product>(request);

        await _productRepository.UpdateAsync(productToUpdate);
        
        return Unit.Value;
    }
}