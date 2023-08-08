using Tutorial.Infstructures.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Mapper
{
    public class SubjectProfile:RoomProfile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDTO>().ReverseMap();
        }
    }
}
