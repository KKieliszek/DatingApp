using DatingApp.Data.Models;
using DatingApp.Data.Models.Dtos;
using DatingApp.Data.Models.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Services
{
    public interface IPhotoService
    {
        Task<PhotoForReturnedDto> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto);
    }
}
