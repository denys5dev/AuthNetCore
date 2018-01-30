using System.Collections.Generic;
using System.Threading.Tasks;
using AuthNetCore.Data;
using AuthNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthNetCore.Repository.UserRepository
{
    public class DatingRepository : Repository<User>, IDatingRepository
    {
        private readonly new DataContext _context;

        public DatingRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users =  await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }
    }
}