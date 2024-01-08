using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository.Contracts;

namespace DesafioNetCore.Application.Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;
    public PersonService(IUnitOfWork PersonOfWork)
    {
        _unitOfWork = PersonOfWork;
    }

    public async Task<Person> AddAsync(Person entity)
    {
        await _unitOfWork.PersonRepository.AddAsync(entity);
        _unitOfWork.Commit();
        return entity;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _unitOfWork.PersonRepository.GetAllAsync();
    }
    // nao vai ser utilizado este
    public async Task<Person> GetByIdAsync(Guid guid)
    {
        return await _unitOfWork.PersonRepository.GetByIdAsync(guid);
    }

    public async Task<Person> GetByShortIdAsync(string shortId)
    {
        return await _unitOfWork.PersonRepository.GetByShortIdAsync(shortId);
    }

    public async Task<Person> UpdateAsync(Person entity)
    {
        await _unitOfWork.PersonRepository.UpdateAsync(entity);
        _unitOfWork.Commit();
        return entity;
    }

    public async Task<bool> DeleteAsync(string shortId)
    {
        var deleted = await _unitOfWork.PersonRepository.DeleteAsync(shortId);
        _unitOfWork.Commit();

        return deleted;
    }
}