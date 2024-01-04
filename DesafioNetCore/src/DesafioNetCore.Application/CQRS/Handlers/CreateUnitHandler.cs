using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Application.CQRS;

public class CreateUnitHandler
{
    private readonly IUnitOfWork _uow;
    public CreateUnitHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public CreateUnitResponse Handle (CreateUnitRequest request)
    {
        Unit unit = new Unit()
        {
            Acronym = request.Acronym,

        };
        _uow.UnitRepository.Add(unit);
        _uow.Commit();
    }
}
