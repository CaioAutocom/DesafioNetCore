using DesafioNetCore.Application.Cqrs;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;

namespace DesafioNetCore.Application.Validation.CreateProductValidator;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Price).NotNull().NotEmpty()
            .WithMessage("Price must be given.")
            .Must((price) => price >= 0m).WithMessage("Price must be a positive value.");

        RuleFor(x => x.BarCode)
            .NotNull().NotEmpty().WithMessage("BarCode must be given.")
            .MustAsync(BarCodeDoesNotExist).WithMessage("The given barcode its already taken on database.");

        RuleFor(x => x.Acronym).NotEmpty().NotNull().WithMessage("Acronym must be given.")
            .MustAsync(AcronymExists).WithMessage("Acronym does not exists in database. You need to create one first and then a product.");
    }
    private async Task<bool> BarCodeDoesNotExist(string barCode, CancellationToken cancellationToken)
    {
        // entendi que se o código estiver vazio poderá ser cadastrado, mas caso haja informação, ele deve ser validado.
        // Código Barras não poderão se repetir ou podem ser vazios.
        if (string.IsNullOrWhiteSpace(barCode)) return true;

        return await _unitOfWork.ProductRepository.BarCodeDoesNotExistAsync(barCode);
    }
    private async Task<bool> AcronymExists(string acronym, CancellationToken cancellationToken) => await _unitOfWork.UnitRepository.GetQueryable(x => x.Acronym == acronym) != null;
}
