﻿using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class GetUnitsResponse : IRequest<Domain.Entities.Unit>
{
    public string ShortId { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
