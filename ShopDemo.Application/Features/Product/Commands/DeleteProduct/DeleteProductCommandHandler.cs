using AutoMapper;
using MediatR;
using ShopDemo.Application.Contracts.ProductRepository;
using ShopDemo.Application.Exceptions;

namespace ShopDemo.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new NotFoundException(nameof(Domain.Product), request.Id);
        }

        await _productRepository.DeleteAsync(product);

        return Unit.Value;
    }
}