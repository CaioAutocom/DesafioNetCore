using DesafioNetCore.Domain.Entities;

namespace DesafioNetCore.Infra.Repository
{
    public interface IUserRespository
    {
        void Add(User user);
        bool Save();
    }
}
