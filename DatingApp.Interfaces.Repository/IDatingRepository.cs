using DatingApp.Data.Models;
using DatingApp.Data.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Repository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<Photo> GetPhoto(int id);
        Task<Photo> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto);
        Task<Photo> GetMainPhotoForUser(int userId);
    }
}
