using AutoMapper;
using Tutorials.Api.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Mapper
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            // source to destiation 
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.User.LastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(s => s.User.Age))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(s => s.User.Gender))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(s => s.User.Image))
                .ReverseMap();

        }
    }

}
