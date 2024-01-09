using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Application.CQRS.Request.Product;
using DesafioNetCore.Application.Services;
using DesafioNetCore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMediator mediator, IMapper mapper)
        {
            _productService = productService;
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit(string shortId, [FromBody] UpdateProductRequest updateRequest)
        {
            // implementar posteriormente o tratamento para validação dos dados.
            var updateResponse = await _mediator.Send(updateRequest);

            return Ok(updateResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<GetProductsResponse>>(await _productService.GetAllAsync()));
        }
        [HttpGet("get-by-shortid")]
        public async Task<IActionResult> GetByShortId(string shortid)
        {
            return Ok(_mapper.Map<GetProductsResponse>(await _productService.GetByShortIdAsync(shortid)));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(string shortId)
        {
            bool deleted = await _productService.DeleteAsync(shortId);
            return Ok(deleted);
        }
    }
}
