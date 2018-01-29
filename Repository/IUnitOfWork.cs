using System;
using AuthNetCore.Models;
using AuthNetCore.Repository.UserRepository;

namespace AuthNetCore.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository { get; }
        int Complete();
    }
}