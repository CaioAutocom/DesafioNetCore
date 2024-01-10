using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;
using System.Xml.Linq;

namespace DesafioNetCore.Application.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Document).IsValidCNPJ().Unless(x => string.IsNullOrWhiteSpace(x.Document) || (!string.IsNullOrWhiteSpace(x.Document) && x.Document.Length <= 14)).WithMessage("The given document is not a valid CNPJ.");
            RuleFor(x => x.Document).MinimumLength(11).WithMessage("The document must contains at least 11 characteres.");
            RuleFor(x => x.Document).MaximumLength(14).WithMessage("The document must contains max 14 characteres.");

            RuleFor(x => x.Document).IsValidCPF().Unless(x => string.IsNullOrWhiteSpace(x.Document) || (!string.IsNullOrWhiteSpace(x.Document) && x.Document.Length >= 11)).WithMessage("The given document is not a valid CPF.");

            RuleFor(x => x.Document).MustAsync(DocumentDoesNotExists).WithMessage("The document given it's already on database.");
            RuleFor(x => x.AlternativeIdentifier).MustAsync(AlternativeCodeDoesNotExist).WithMessage("The alternative Identifier given it's already on database.");

        }
        private async Task<bool> DocumentDoesNotExists(string document,CancellationToken cancellationToken)
        {
            // há um ponto no desafio que diz que o documento pode ser vazio, mas não pode ser duplicado no banco, então se for vazio nem é necessário ir no banco verificar se existe um cadastro vazio.
            if (string.IsNullOrWhiteSpace(document)) return true;

            return await _unitOfWork.PersonRepository.GetByDocAsync(document) == null;
        }

        private async Task<bool> AlternativeCodeDoesNotExist(string alternativeCode, CancellationToken cancellationToken) => await _unitOfWork.PersonRepository.GetByAlternativeCode(alternativeCode) == null;
    }
}
