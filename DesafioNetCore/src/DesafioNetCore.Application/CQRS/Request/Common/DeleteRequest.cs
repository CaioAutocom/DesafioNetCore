﻿using MediatR;

namespace DesafioNetCore.Application.CQRS;

public class DeleteRequest : IRequest<bool>
{
    public string ShortId { get; set; } = string.Empty;
    public Guid Id { get; set; }
}
