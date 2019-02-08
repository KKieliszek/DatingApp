using AutoMapper;
using DatingApp.Data.Models.Dtos;
using DatingApp.Data.Models.RequestDtos;
using DatingApp.Interfaces.Repository;
using DatingApp.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController: ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;   

        public PhotosController(IDatingRepository repo, IMapper mapper, 
            IPhotoService photoService)
        {
            _repo = repo;
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);

            var photo = _mapper.Map<PhotoForReturnedDto>(photoFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, 
            [FromForm] PhotoForCreationDto photoForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var photo = await _photoService.AddPhotoForUser(userId, photoForCreationDto);

            return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photo);

        }

    }
}
