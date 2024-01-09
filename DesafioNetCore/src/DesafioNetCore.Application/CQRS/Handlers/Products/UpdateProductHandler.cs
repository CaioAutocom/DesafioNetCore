using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS.Request.Product;
using DesafioNetCore.Domain.Entities;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class UpdateProductHandle : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public UpdateProductHandle(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var newUnit = _mapper.Map<Product>(request);
        return _mapper.Map<UpdateProductResponse>(await _productService.AddAsync(newUnit));
    }
}
