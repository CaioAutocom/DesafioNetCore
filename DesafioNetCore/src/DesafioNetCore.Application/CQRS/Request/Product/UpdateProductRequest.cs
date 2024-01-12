using MediatR;

namespace DesafioNetCore.Application.CQRS.Request.Product
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public string ShortId { get; set; } = string.Empty;
        public  string FullDescription { get; set; } = string.Empty;
        public  string ShortDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Storage { get; set; }
        public string BarCode { get; set; } = string.Empty;
        public bool CanSell { get; set; }
        public bool Active { get; set; }
        public string Acronym { get; set; } = string.Empty;
    }
}
