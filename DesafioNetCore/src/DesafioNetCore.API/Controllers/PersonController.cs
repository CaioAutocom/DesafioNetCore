using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers;

[Route("[controller]")]
public class PersonController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IPersonService _personService;

    public PersonController(IMapper mapper, IMediator mediator, IPersonService personService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _personService = personService;
    }


    [HttpPost]
    public async Task<IActionResult> Add(CreatePersonRequest request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUnit(string shortId, UpdatePersonRequest updateRequest)
    {
        // implementar posteriormente o tratamento para validação dos dados.
        var updateResponse = await _mediator.Send(updateRequest);

        return Ok(updateResponse);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_mapper.Map<List<GetPersonsResponse>>(await _personService.GetAllAsync()));
    }
    [HttpGet("get-by-shortid")]
    public async Task<IActionResult> GetByShortId(string shortid)
    {
        return Ok(_mapper.Map<GetPersonsResponse>(await _personService.GetByShortIdAsync(shortid)));
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteById(string shortId)
    {
        return Ok(await _mediator.Send(shortId));
    }
}