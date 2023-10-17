using FluentValidation;
using ShopDemo.Application.Contracts.ProductRepository;

namespace ShopDemo.Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(ProductMustExist);
        
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(q => q)
            .MustAsync(ProductNameUnique)
            .WithMessage("Product already exists");

        this._productRepository = productRepository;
    }
    
    private async Task<bool> ProductMustExist(int id, CancellationToken arg2)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product != null;
    }

    private async Task<bool> ProductNameUnique(UpdateProductCommand command, CancellationToken token)
    {
        return await _productRepository.IsProductNameUnique(command.Name);
    }
}