using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [Route("[controller]")]
    public class UnitController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitService _unitService;

        public UnitController(IMapper mapper, IMediator mediator, IUnitService unitService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _unitService = unitService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateUnitRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit(string acronym, [FromBody] UpdateUnitRequest updateRequest)
        {
            // implementar posteriormente o tratamento para validação dos dados.
            var updateResponse = await _mediator.Send(updateRequest);

            return Ok(updateResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<GetUnitsResponse>>(await _unitService.GetAllAsync()));
        }
        [HttpGet("get-by-shortid")]
        public async Task<IActionResult> GetByShortId(string shortid)
        {
            return Ok(_mapper.Map<GetUnitsResponse>(await _unitService.GetByShortIdAsync(shortid)));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(string shortId)
        {
            return Ok(await _mediator.Send(shortId));
        }
    }
}
