using DesafioNetCore.Application.CQRS;
using MediatR;

namespace DesafioNetCore.Application.Cqrs;

public class DeleteProductRequest : DeleteRequest, IRequest<bool>
{
    public DeleteProductRequest()
    {
    }
}
