using AuthNetCore.Data;
using AuthNetCore.Repository.UserRepository;

namespace AuthNetCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new AuthRepository(_context);
        }
        public IAuthRepository Users { get; private set; }
        
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