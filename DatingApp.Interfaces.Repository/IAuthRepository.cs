using DatingApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(string username, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
