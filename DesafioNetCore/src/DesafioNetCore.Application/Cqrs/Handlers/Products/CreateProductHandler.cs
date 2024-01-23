using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public CreateProductHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var newUnit = _mapper.Map<Product>(request);
        return _mapper.Map<CreateProductResponse>(await _productService.AddAsync(newUnit));
    }
}
