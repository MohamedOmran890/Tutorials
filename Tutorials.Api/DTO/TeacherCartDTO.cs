using Tutorials.Data.Entities;
using Tutorials.Data.Enums ;

namespace Tutorials.Api.DTO
{
    public class TeacherCartDto
    {
        public int TeacherId { get; set; }
        public string Bio { get; set; }
        public City city  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; }
    }
}
