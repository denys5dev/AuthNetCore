using System.Linq;
using AuthNetCore.Helpers;
using AuthNetCore.Models;
using AuthNetCore.Resources;
using AutoMapper;

namespace AuthNetCore.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserForListResource>()
                .ForMember(ul => ul.PhotoUrl, opt => opt.MapFrom(u => u.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(ul => ul.Age, opt => opt.ResolveUsing(d => d.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailsResource>()
                .ForMember(ul => ul.PhotoUrl, opt => opt.MapFrom(u => u.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(ul => ul.Age, opt => opt.ResolveUsing(d => d.DateOfBirth.CalculateAge()));
                
            CreateMap<Photo, PhotoResource>();
        }
    }
}