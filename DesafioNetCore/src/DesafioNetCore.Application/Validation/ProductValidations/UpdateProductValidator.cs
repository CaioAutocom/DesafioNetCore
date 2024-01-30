using DesafioNetCore.Application.Cqrs.Request.Product;
using DesafioNetCore.Infra.Repository.Contracts;
using FluentValidation;
using MediatR;

namespace DesafioNetCore.Application.Validation.CreateProductValidator;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price must be given.").Must((price) => price >= 0m).WithMessage("Price must be a positive value.");
        RuleFor(x => x.BarCode).NotNull().NotEmpty().WithMessage("BarCode must be given.").MustAsync(BarCodeDoesNotExist).WithMessage("The given barcode its already taken on database.");
        RuleFor(x => x.Acronym).NotEmpty().NotNull().WithMessage("Acronym must be given.").MustAsync(AcronymExists).WithMessage("Acronym does not exists in database. Insert a valid one.");
    }
    private async Task<bool> BarCodeDoesNotExist(UpdateProductRequest request, string barCode, CancellationToken cancellationToken)
    {
        // entendi que se o código estiver vazio poderá ser cadastrado, mas caso haja informação, ele deve ser validado.
        // Código Barras não poderão se repetir ou podem ser vazios.
        if (string.IsNullOrWhiteSpace(barCode)) return true;

        return await _unitOfWork.ProductRepository.GetQueryable(x => x.ShortId != request.ShortId && x.BarCode == barCode) == null;
    }
    private async Task<bool> AcronymExists(UpdateProductRequest request, string acronym, CancellationToken cancellationToken) => await _unitOfWork.UnitRepository.GetQueryable(x => x.ShortId != request.ShortId && x.Acronym == acronym) != null;
}
