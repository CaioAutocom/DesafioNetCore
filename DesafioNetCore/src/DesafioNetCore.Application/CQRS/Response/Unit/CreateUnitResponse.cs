﻿using MediatR;

namespace DesafioNetCore.Application.CQRS;
public class CreateUnitResponse : IRequest<CreateUnitResponse>
{
    public Guid Id { get; set; }
    public string ShortId { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
