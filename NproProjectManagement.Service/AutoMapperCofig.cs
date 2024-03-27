using AutoMapper;
using Common.Models;
using Common.ViewModels;

namespace Services
{
    public class AutoMapperCofig : Profile
    {
        public AutoMapperCofig() 
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Role, RoleResponse>().ReverseMap();
            CreateMap<Status, StatusResponse>().ReverseMap();
        }
    }
}
