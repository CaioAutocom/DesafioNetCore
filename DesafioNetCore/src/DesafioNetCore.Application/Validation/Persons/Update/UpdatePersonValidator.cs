using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;

namespace DesafioNetCore.Application.Validation;

public class UpdatePersonValidator : AbstractValidator<UpdatePersonRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePersonValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Document).MinimumLength(11).WithMessage("The document must contains at least 11 characteres.");
        RuleFor(x => x.Document).MaximumLength(14).WithMessage("The document must contains max 14 characteres.");
        RuleFor(x => x.Document).IsValidCNPJ().Unless(x => string.IsNullOrWhiteSpace(x.Document) || !string.IsNullOrWhiteSpace(x.Document) && x.Document.Length <= 14).WithMessage("The given document is not a valid CNPJ.");

        RuleFor(x => x.Document).IsValidCPF().Unless(x => string.IsNullOrWhiteSpace(x.Document) || !string.IsNullOrWhiteSpace(x.Document) && x.Document.Length >= 11).WithMessage("The given document is not a valid CPF.");

        RuleFor(x => x.Document).MustAsync(DocumentDoesNotExists).WithMessage("The given document it's already on database.");
        RuleFor(x => x.AlternativeIdentifier).MustAsync(AlternativeCodeDoesNotExist).WithMessage("The alternative Identifier given it's already on database.");

    }


    private async Task<bool> DocumentDoesNotExists(UpdatePersonRequest person, string document, CancellationToken cancellationToken)
    {
        // há um ponto no desafio que diz que o documento pode ser vazio, mas não pode ser duplicado no banco, então se for vazio nem é necessário ir no banco verificar se existe um cadastro vazio.
        if (string.IsNullOrWhiteSpace(document)) return true;

        return await _unitOfWork.PersonRepository.GetQueryable(x => x.ShortId != person.ShortId && x.Document == document) == null;
    }

    private async Task<bool> AlternativeCodeDoesNotExist(UpdatePersonRequest person, string alternativeCode, CancellationToken cancellationToken)
    {
        return await _unitOfWork.PersonRepository.GetQueryable(x => x.ShortId != person.ShortId && x.AlternativeIdentifier == alternativeCode) == null;
    }
}
