using DatingApp.Data.Models.Dtos;
using DatingApp.Data.Models.RequestDtos;
using CloudinaryDotNet.Actions;
using System.Threading.Tasks;

namespace DatingApp.Interfaces.Services
{
    public interface IPhotoService
    {
        Task<PhotoForReturnedDto> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto);

        DeletionResult DeletePhoto(string photoPublicId);
    }
}
