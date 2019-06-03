using DatingApp.Data.Models;
using DatingApp.Data.Models.RequestDtos;
using DatingApp.Data.Models.RepoModels;
using System.Threading.Tasks;
using DatingApp.Models.RequestModels;
using System.Collections.Generic;

namespace DatingApp.Interfaces.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
        Task<Photo> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto);
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Like> GetLike(int userId, int recipientId);
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser();
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
    }
}
