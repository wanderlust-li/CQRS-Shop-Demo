using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Application.Exceptions;

namespace ShopDemo.Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator(_productRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Product", validationResult);

        
        var createProduct = _mapper.Map<Domain.Product>(request);
        await _productRepository.CreateAsync(createProduct);

        return createProduct.Id;
    }
}