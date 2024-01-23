using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Cqrs;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, bool>
{
    private readonly IProductService _productService;
    public DeleteProductHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        return await _productService.DeleteAsync(request.ShortId);
    }
}
