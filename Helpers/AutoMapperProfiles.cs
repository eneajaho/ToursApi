using AutoMapper;
using ToursApi.DTOs.User;
using ToursApi.Entities;

namespace ToursApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, AuthUserDto>();
            CreateMap<User, UserDto>();

            CreateMap<AuthUserDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();


            // .ForMember(dest => dest.PhotoUrl, opt
            //     => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            // .ForMember(dest => dest.Age, opt
            //     => opt.MapFrom(src => src.Birthday.CalculateAge()));
            // CreateMap<MemberUpdateDto, User>();
        }
    }
}