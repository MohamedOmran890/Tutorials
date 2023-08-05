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
                .ReverseMap();

        }
    }

}
