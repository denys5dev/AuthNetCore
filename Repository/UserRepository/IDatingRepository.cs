using System.Collections.Generic;
using System.Threading.Tasks;
using AuthNetCore.Models;

namespace AuthNetCore.Repository.UserRepository
{
    public interface IDatingRepository : IRepository<User>
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}