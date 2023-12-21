using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAll()
        //{
        //    return _productService.GetAll();
        //}
        //[HttpPost]
        //public void Add(Product product)
        //{
        //    _productService.Add(product);
        //}

    }
}
