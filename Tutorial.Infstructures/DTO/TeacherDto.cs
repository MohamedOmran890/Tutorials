using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.DTO
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string Bio { get; set; }
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public byte[]? Image { get; set; }
    }
}
