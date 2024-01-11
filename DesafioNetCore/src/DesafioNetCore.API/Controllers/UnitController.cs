using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    [Route("[controller]")]
    public class UnitController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitService _unitService;
        private readonly IValidator<Domain.Entities.Unit> _validator;

        public UnitController(IMapper mapper, IMediator mediator, IUnitService unitService, IValidator<Domain.Entities.Unit> validator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _unitService = unitService;
            _validator = validator;
        }


        [HttpPost]
        [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
        public async Task<IActionResult> Add(CreateUnitRequest request)
        {
            var validationResult = await _validator.ValidateAsync(_mapper.Map<Domain.Entities.Unit>(request));
            
            if (!validationResult.IsValid)
            {
                AddErrors(validationResult.Errors);
                return CustomResponse(validationResult);
            }
            return Ok(await _mediator.Send(request));
            
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
        public async Task<IActionResult> UpdateUnit(string acronym, [FromBody] UpdateUnitRequest updateRequest)
        {
            var validationResult = await _validator.ValidateAsync(_mapper.Map<Domain.Entities.Unit>(updateRequest));

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
            return Ok(_mapper.Map<List<GetUnitsResponse>>(await _unitService.GetAllAsync()));
        }
        [HttpGet("get-by-shortid")]
        public async Task<IActionResult> GetByShortId(string shortid)
        {
            return Ok(_mapper.Map<GetUnitsResponse>(await _unitService.GetByShortIdAsync(shortid)));
        }
        [HttpDelete]
        [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
        public async Task<IActionResult> DeleteById(string shortId)
        {
            return Ok(await _mediator.Send(shortId));
        }
    }
}
