using System.Linq;
using AutoMapper;
using DatingApp.API.DTO;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForDetailDTO>()
            .ForMember(dest => dest.photoUrl, 
                       opt => opt.MapFrom(src => src.photos.FirstOrDefault(p => p.isMain).url))
            .ForMember(dest => dest.Age,
                       opt => opt.MapFrom(src => src.dateOfBirth.CalculateAge()));
            CreateMap<UserForDetailDTO, User>();

            CreateMap<User, UserForListDTO>()
            .ForMember(dest => dest.photoUrl, 
                       opt => opt.MapFrom(src => src.photos.FirstOrDefault(p => p.isMain).url))
            .ForMember(dest => dest.age,
                       opt => opt.MapFrom(src => src.dateOfBirth.CalculateAge()));
            CreateMap<UserForListDTO, User>();

            CreateMap<Photo, PhotosForDetailedDTO>();
            CreateMap<PhotosForDetailedDTO, Photo>();
        }
    }
}