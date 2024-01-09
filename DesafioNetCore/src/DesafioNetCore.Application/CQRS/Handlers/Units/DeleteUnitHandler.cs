using DesafioNetCore.Application.Contracts;
using MediatR;

namespace DesafioNetCore.Application.CQRS
{
    public class DeleteUnitHandler : IRequestHandler<DeleteRequest, bool>
    {
        private readonly IUnitService _unitService;
        public DeleteUnitHandler(IUnitService unitService)
        {
            _unitService = unitService;
        }

        async Task<bool> IRequestHandler<DeleteRequest, bool>.Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            return await _unitService.DeleteAsync(request.ShortId); 
        }
    }
}
