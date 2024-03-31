using AutoMapper;
using Common.ViewModels;
using NproProjectManagement.Common.Models;

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
