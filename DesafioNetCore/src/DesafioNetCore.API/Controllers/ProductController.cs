using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Application.CQRS.Request.Product;
using DesafioNetCore.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IValidator<Product> _validator;
        public ProductController(IProductService productService, IMediator mediator, IMapper mapper, IValidator<Product> validator)
        {
            _productService = productService;
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest updateRequest)
        {
            // verificar a melhor opção para tratar esse caso.
            if (updateRequest.CanSell && User.Identity.IsAuthenticated && User.IsInRole("SELLER")) return CustomResponse("Sellers are not allowed to set the property 'CanSell' as true.");
            if (!updateRequest.Active && User.Identity.IsAuthenticated && User.IsInRole("SELLER")) return CustomResponse("Sellers are not allowed to unable a product.");

            return Ok(await _mediator.Send(updateRequest));
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
        [HttpGet("get-all-vendable-products")]
        public async Task<IActionResult> GetAllVendable()
        {
            return Ok(_mapper.Map<List<GetProductsResponse>>(await _productService.GetAllVendableProducts()));
        }
        [HttpDelete]
        [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
        public async Task<IActionResult> DeleteById(string shortId)
        {
            return Ok(await _mediator.Send(shortId));
        }
    }
}
