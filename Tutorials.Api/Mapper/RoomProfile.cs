using AutoMapper;
using Tutorial.Infstructures.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Mapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {

            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.SizeRoom, opt => opt.MapFrom(s => s.SizeRoom))
                .ForMember(dest => dest.CurrentStudentNumber, opt => opt.MapFrom(s => s.CurrentStudentNumber))
                .ForMember(dest => dest.TypeRoom, opt => opt.MapFrom(s => s.TypeRoom))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(s => s.Center.Address.Region))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(s => s.Teacher.User.FirstName + s.Teacher.User.LastName))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(s => s.Subject.Name))
                .ForMember(dest => dest.levelName, opt => opt.MapFrom(s => s.Level.Name))
                .ReverseMap();

        }
    }

}
