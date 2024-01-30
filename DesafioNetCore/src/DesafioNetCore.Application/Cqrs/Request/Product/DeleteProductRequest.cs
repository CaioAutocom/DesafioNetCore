using DesafioNetCore.Application.Cqrs;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class DeleteProductRequest : DeleteRequest, IRequest<bool>
{
    public DeleteProductRequest()
    {
    }
}
