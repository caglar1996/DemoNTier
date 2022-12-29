using DAL.Context;
using DAL.Entities;
using Repo.Interfaces;

namespace Repo.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly DemoContext context;
        public UserRepository(DemoContext context)
        {
            this.context = context;
        }

        public User GetUser(int id)
        {
            return context.User.Find(id);
        }

        public bool UpdateUser(int id, string name, int age)
        {

            var entity = context.User.Find(id);

            if (entity == null)
                return false;

            entity.Name = name;
            entity.Age = age;

            context.Update(entity);

            return context.SaveChanges() > 0 ? true : false;
        }

        public void Dispose()
        {
            if (context != null)            
                context.Dispose();                           
        }
    }
}
