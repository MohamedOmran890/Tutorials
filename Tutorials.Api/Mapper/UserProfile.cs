using AutoMapper;
using Tutorials.Api.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Mapper 
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // source to destiation 
            CreateMap<RegisterDTO, User>().ReverseMap();
           
        }
    }

}
