using System;
using AuthNetCore.Models;
using AuthNetCore.Repository.UserRepository;

namespace AuthNetCore.Repository
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        int Complete();
    }
}