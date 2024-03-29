﻿using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class CreateUnitRequest : IRequest<CreateUnitResponse>
{
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
