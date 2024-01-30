using DesafioNetCore.Application.Cqrs;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class UpdateUnitValidator : AbstractValidator<UpdateUnitRequest>
{
    public UpdateUnitValidator()
    {
        RuleFor(x => x.ShortId)
            .NotNull().NotEmpty().WithMessage("ShortId cannot be empty.");
    }
}
