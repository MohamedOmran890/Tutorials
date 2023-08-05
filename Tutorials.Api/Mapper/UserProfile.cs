using AutoMapper;
using Tutorial.Infstructures.DTO;
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
