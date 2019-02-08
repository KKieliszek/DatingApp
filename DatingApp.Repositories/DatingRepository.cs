using AutoMapper;
using DatingApp.Data;
using DatingApp.Data.Models;
using DatingApp.Data.Models.RequestDtos;
using DatingApp.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Repositories
{
    class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DatingRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

     

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);

        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<Photo> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto)
        {
            var userFromRepo = await GetUser(userId);

            var photo = _mapper.Map<Photo>(photoForCreationDto);

            if (!userFromRepo.Photos.Any(u => u.isMain))
                photo.isMain = true;

            userFromRepo.Photos.Add(photo);

            await SaveAll();

            return photo;

        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
