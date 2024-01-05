using AutoMapper;
using DesafioNetCore.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [Route("[controller]")]
    public class UnitController : MainController
    {
        private readonly IMapper _mapper;

        public UnitController(IMapper mapper)
        {
            _mapper = mapper;
        }
        //[HttpGet]
        //public IEnumerable<GetAllUnitResponse> GetAll() 
        //{
        //    var T = await _unitService.GetAll();
        //}

        [HttpPost]
        public async Task<CreateUnitResponse> Add([FromServices]IMediator mediator, CreateUnitRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
