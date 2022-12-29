using DAL.Entities;

namespace Repo.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        public User GetUser(int id);
        public bool UpdateUser(int id, string name, int age);
    }
}
