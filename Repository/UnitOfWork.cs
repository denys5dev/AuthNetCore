using AuthNetCore.Data;
using AuthNetCore.Models;
using AuthNetCore.Repository.UserRepository;

namespace AuthNetCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private  AuthRepository _authRepository;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        
        }
        public IAuthRepository AuthRepository
        {
            get
            {
                return _authRepository = _authRepository ?? new AuthRepository(_context);
            }
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}