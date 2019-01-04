﻿using AutoMapper;
using DatingApp.Data.Models;
using DatingApp.Data.Models.Dtos;
using System.Linq;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(s => s.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailsDto>()
                 .ForMember(dest => dest.PhotoUrl, opt =>
                 {
                     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
                 })
                  .ForMember(dest => dest.Age, opt =>
                  {
                      opt.MapFrom(s => s.DateOfBirth.CalculateAge());
                  });
            CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}