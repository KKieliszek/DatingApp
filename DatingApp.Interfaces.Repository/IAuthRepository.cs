using DatingApp.Data.Models;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Repository
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User userToCreate, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
