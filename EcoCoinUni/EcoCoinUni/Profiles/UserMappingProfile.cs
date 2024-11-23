using AutoMapper;
using EcoCoinUni.Dtos.UserDtos;
using EcoCoinUni.Entities;

namespace EcoCoinUni.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}
