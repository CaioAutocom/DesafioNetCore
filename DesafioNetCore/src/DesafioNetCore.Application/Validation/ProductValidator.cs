using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;
using System.Runtime.CompilerServices;

namespace DesafioNetCore.Application.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price must be given.")
                .Must(PositiveValue).WithMessage("Price must be a positive value.");
            RuleFor(x => x.BarCode).NotNull().NotEmpty().WithMessage("BarCode must be given.")
                .MustAsync(BarCodeDoesNotExist);

            RuleFor(x => x.Acronym).NotEmpty().NotNull().WithMessage("Acronym must be given.")
                .MustAsync(AcronymExists).WithMessage("Acronym does not exists in database. You need to create one first and then a product.");
        }
        private bool PositiveValue(decimal price) => price >= 0m;
        private async Task<bool> BarCodeDoesNotExist(string barCode, CancellationToken cancellationToken)
        {
            // entendi que se o código estiver vazio poderá ser cadastrado, mas caso haja informação, ele deve ser validado.
            // Código Barras não poderão se repetir ou podem ser vazios.
            if (string.IsNullOrWhiteSpace(barCode)) return true;
            
            return await _unitOfWork.ProductRepository.BarCodeDoesNotExistAsync(barCode);
        }
        private async Task<bool> AcronymExists (string acronym, CancellationToken cancellationToken) => await _unitOfWork.UnitRepository.GetByAcronymAsync(acronym) != null;
    }
}
