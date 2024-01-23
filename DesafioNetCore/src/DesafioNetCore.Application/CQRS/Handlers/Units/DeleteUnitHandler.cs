using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Cqrs;
using MediatR;

namespace DesafioNetCore.Application.CQRS
{
    public class DeleteUnitHandler : IRequestHandler<DeleteUnitRequest, bool>
    {
        private readonly IUnitService _unitService;
        public DeleteUnitHandler(IUnitService unitService)
        {
            _unitService = unitService;
        }
        public async Task<bool> Handle(DeleteUnitRequest request, CancellationToken cancellationToken)
        {
            return await _unitService.DeleteAsync(request.ShortId); 
        }
    }
}
