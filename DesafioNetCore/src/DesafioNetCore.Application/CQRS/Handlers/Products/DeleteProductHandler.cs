using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeleteProductHandler : IRequestHandler<DeleteRequest, bool>
{
    private readonly IProductService _productService;
    public DeleteProductHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<bool> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        return await _productService.DeleteAsync(request.ShortId);
    }
}
