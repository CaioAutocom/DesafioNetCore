using DesafioNetCore.Domain.Entities;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class UnitValidator : AbstractValidator<Unit>
{
    public UnitValidator()
    {
        RuleFor(x => x.Acronym).NotNull().NotEmpty();
    }
}
