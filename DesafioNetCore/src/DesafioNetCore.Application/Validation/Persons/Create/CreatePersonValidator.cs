using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreatePersonValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Document).IsValidCNPJ().Unless(x => string.IsNullOrWhiteSpace(x.Document) || !string.IsNullOrWhiteSpace(x.Document) && x.Document.Length <= 14).WithMessage("The given document is not a valid CNPJ.");
        RuleFor(x => x.Document).MinimumLength(11).WithMessage("The document must contains at least 11 characteres.");
        RuleFor(x => x.Document).MaximumLength(14).WithMessage("The document must contains max 14 characteres.");
        RuleFor(x => x.Document).IsValidCPF().Unless(x => string.IsNullOrWhiteSpace(x.Document) || !string.IsNullOrWhiteSpace(x.Document) && x.Document.Length >= 11).WithMessage("The given document is not a valid CPF.");

        RuleFor(x => x.Document).MustAsync(DocumentDoesNotExists).WithMessage("The given document it's already on database.");
        RuleFor(x => x.AlternativeIdentifier).MustAsync(AlternativeCodeDoesNotExist).WithMessage("The alternative Identifier given it's already on database.");
    }

    private async Task<bool> AlternativeCodeDoesNotExist(string alternativeIdentifier, CancellationToken token)
    {
        return await _unitOfWork.PersonRepository.GetQueryable(x => x.AlternativeIdentifier == alternativeIdentifier) == null;
    }

    private async Task<bool> DocumentDoesNotExists(string document, CancellationToken token)
    {
        return await _unitOfWork.PersonRepository.GetQueryable(x => x.Document == document) == null;
    }
}
