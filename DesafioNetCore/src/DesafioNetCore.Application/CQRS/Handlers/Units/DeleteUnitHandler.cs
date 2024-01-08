using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS.Request.Unit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioNetCore.Application.CQRS.Handlers.Units
{
    public class DeleteUnitHandler : IRequestHandler<DeleteRequest, bool>
    {
        private readonly IUnitService _unitService;
        public DeleteUnitHandler(IUnitService unitService)
        {
            _unitService = unitService;
        }


        Task<bool> IRequestHandler<DeleteRequest, bool>.Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            return _unitService.DeleteAsync(request.ShortId); 
        }
    }
}
