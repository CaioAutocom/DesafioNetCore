using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

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

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _unitOfWork.UnitRepository.GetAllAsync();
        }
        // nao vai ser utilizado este
        public async Task<Unit> GetByIdAsync(Guid guid)
        {
            return await _unitOfWork.UnitRepository.GetByIdAsync(guid);
        }

        public async Task<Unit> GetByAcronym(string acronym)
        {
            return await _unitOfWork.UnitRepository.GetByAcronym(acronym);
        }

        public async Task<Unit> GetByShortIdAsync(string shortId)
        {
            return await _unitOfWork.UnitRepository.GetByShortIdAsync(shortId);
        }

        public async Task<Unit> UpdateAsync(Unit entity)
        {
            await _unitOfWork.UnitRepository.UpdateAsync(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public async Task<bool> DeleteAsync(string shortId)
        {
            var deleted = await _unitOfWork.UnitRepository.DeleteAsync(shortId);
            _unitOfWork.Commit();

            return deleted;
        }
    }
}
