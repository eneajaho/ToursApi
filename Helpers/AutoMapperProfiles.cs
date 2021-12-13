using AutoMapper;
using ToursApi.DTOs.Package;
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
            CreateMap<SelfUserUpdateDto, User>();

            CreateMap<Package, PackageDto>();
            CreateMap<PackageDto, Package>();
            CreateMap<PackageUpdateDto, Package>();
            CreateMap<PackageCreateDto, Package>();


            // .ForMember(dest => dest.PhotoUrl, opt
            //     => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            // .ForMember(dest => dest.Age, opt
            //     => opt.MapFrom(src => src.Birthday.CalculateAge()));
            // CreateMap<MemberUpdateDto, User>();
        }
    }
}