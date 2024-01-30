using DesafioNetCore.Application.Cqrs;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class CreateUnitValidator : AbstractValidator<CreateUnitRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateUnitValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Acronym)
            .NotNull().NotEmpty().WithMessage("Acronyn cannot be empty.")
            .MustAsync(AcronymDoesNotExist).WithMessage("Acronym already exists.");

    }
    private async Task<bool> AcronymDoesNotExist(string acronym, CancellationToken token) => await _unitOfWork.UnitRepository.GetByAcronymAsync(acronym) == null;

}
