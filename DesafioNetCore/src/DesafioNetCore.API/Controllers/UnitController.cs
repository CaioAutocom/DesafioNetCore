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
       

        [HttpPost]
        public async Task<CreateUnitResponse> Add([FromServices]IMediator mediator, CreateUnitRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit(string acronym,
            [FromServices] IMediator mediator,
            [FromBody] UpdateUnitRequest updateRequest)
        {
            // implementar posteriormente o tratamento para validação dos dados.
            var updateResponse = await mediator.Send(updateRequest);


            return Ok(updateResponse);
        }
    }
}
