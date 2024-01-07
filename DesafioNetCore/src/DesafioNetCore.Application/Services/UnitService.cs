using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioNetCore.Application.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> AddAsync(Unit entity) 
        {
            await _unitOfWork.UnitRepository.AddAsync(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public Task<Unit> Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _unitOfWork.UnitRepository.GetAllAsync();
        }

        public Task<Unit> GetByIdAsyn(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> GetByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> GetByShortId(string shortId)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> GetByShortIdAsync(string shortId)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Update(Unit entity)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> UpdateAsync(Unit entity)
        {
            throw new NotImplementedException();
        }
    }
}
