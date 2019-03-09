using AutoMapper;
using UserProjects.DAL.Models;
using Web.Api.Models;

namespace Web.Api.Mapping.Profiles
{
    

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<User ,UserModel >()
            ;
        }
    }
}
