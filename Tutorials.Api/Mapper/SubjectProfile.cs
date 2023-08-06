using Tutorials.Api.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Mapper
{
    public class SubjectProfile:RoomProfile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>().ReverseMap();
        }
    }
}
