using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class UnitValidator : AbstractValidator<Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public UnitValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Acronym)
            .NotNull().NotEmpty().WithMessage("Acronyn cannot be empty.")
            .MustAsync(AcronymDoesNotExist).WithMessage("Acronym already exists.");
            
    }

    private async Task<bool> AcronymDoesNotExist(string acronym, CancellationToken token) => await _unitOfWork.UnitRepository.GetByAcronymAsync(acronym) == null;
   
}
