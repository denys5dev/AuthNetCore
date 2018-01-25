using System.Threading.Tasks;
using AuthNetCore.Models;

namespace AuthNetCore.Repository.UserRepository
{
    public interface IAuthRepository : IRepository<User>
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
    }
}