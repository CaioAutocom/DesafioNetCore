﻿using AutoMapper;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
    public async Task<IActionResult> Add(CreatePersonRequest request)
    {  
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    [Authorize(Roles = "ADMINISTRATOR, MANAGER")]
    public async Task<IActionResult> UpdatePerson(UpdatePersonRequest updateRequest)
    {
        return Ok(await _mediator.Send(updateRequest));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllPersonsRequest()));
    }
    [HttpGet("get-by-shortid")]
    public async Task<IActionResult> GetByShortId(string shortid)
    {
        return Ok(await _mediator.Send(new GetPersonByShortIdRequest { ShortId = shortid }));
    }

    [HttpGet("get-clients")]
    public async Task<IActionResult> GetClients()
    {
        return Ok(await _mediator.Send(new GetAllClientsRequest()));
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteById(DeletePersonRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
}