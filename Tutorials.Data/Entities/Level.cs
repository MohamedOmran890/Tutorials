namespace Tutorials.Data.Entities
{
    public class Level
    {
        public Level()
        {
 
        }
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers {get; set;}
    }
}