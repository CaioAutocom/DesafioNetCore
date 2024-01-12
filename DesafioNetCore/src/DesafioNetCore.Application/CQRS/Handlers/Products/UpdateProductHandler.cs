using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS.Request.Product;
using DesafioNetCore.Application.Services;
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
        var existingProduct = await _productService.GetByShortIdAsync(request.ShortId);

        if (existingProduct == null) throw new Exception("Something went wrong. There is no any register with the given request.");

        // atualiza o produto existente com o que veio no request
        _mapper.Map(request, existingProduct);

        await _productService.UpdateAsync(existingProduct);
        // tirar dúvida se essa é a prática correta, onde recebo o request, carrego a pessoa, mapeio o request para a pessoa que está sendo trackeada, e após o update, mapeio o request para um novo response.
        return _mapper.Map(existingProduct, new UpdateProductResponse());
    }
}
