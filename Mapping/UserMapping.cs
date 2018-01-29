using AuthNetCore.Models;
using AuthNetCore.Resources;
using AutoMapper;

namespace AuthNetCore.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserResource>()
                .ForMember(ur => ur.Username, opt => opt.MapFrom(u => u.Username))
                .ForMember(ur => ur.Email, opt => opt.MapFrom(u => u.Email));
            
            CreateMap<User, UserLogin>()
                .ForMember(ur => ur.Username, opt => opt.MapFrom(u => u.Username));
        }
    }
}