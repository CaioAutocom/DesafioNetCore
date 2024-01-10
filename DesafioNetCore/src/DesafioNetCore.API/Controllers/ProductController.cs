using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Application.CQRS.Request.Product;
using DesafioNetCore.Application.Services;
using DesafioNetCore.Domain.Entities;
using FluentValidation;
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
            var validationResult = await _validator.ValidateAsync(_mapper.Map<Product>(request));

            if (!validationResult.IsValid)
            {
                AddErrors(validationResult.Errors);
                return CustomResponse(validationResult);
            }
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit(string shortId, [FromBody] UpdateProductRequest updateRequest)
        {
            var validationResult = await _validator.ValidateAsync(_mapper.Map<Product>(updateRequest));

            if (!validationResult.IsValid)
            {
                AddErrors(validationResult.Errors);
                return CustomResponse(validationResult);
            }

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
            return Ok(await _mediator.Send(shortId));
        }
    }
}
