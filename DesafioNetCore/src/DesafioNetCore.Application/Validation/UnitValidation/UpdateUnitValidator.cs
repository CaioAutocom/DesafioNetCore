using DesafioNetCore.Application.CQRS;
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
