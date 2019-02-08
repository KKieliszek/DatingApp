using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.Data.Models;
using DatingApp.Data.Models.Dtos;
using DatingApp.Data.Models.RequestDtos;
using DatingApp.Interfaces.Repository;
using DatingApp.Interfaces.Services;
using DatingApp.Services.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace DatingApp.Services
{
    class PhotoService : IPhotoService
    {
        private readonly IDatingRepository _repo;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly IMapper _mapper;

        public PhotoService(IDatingRepository repo, IOptions<CloudinarySettings> cloudinaryConfig,
            IMapper mapper)
        {
            _repo = repo;
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;

            Account acc = new Account(
                _cloudinaryConfig.Value.Cloudname,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<PhotoForReturnedDto> AddPhotoForUser(int userId, PhotoForCreationDto photoForCreationDto)
        {
            var file = photoForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = await _repo.AddPhotoForUser(userId, photoForCreationDto);

            return _mapper.Map<PhotoForReturnedDto>(photo);
        }
    }
}
