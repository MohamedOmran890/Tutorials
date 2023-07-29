using System.ComponentModel.DataAnnotations;
using System.Timers;
using Tutorials.Data.Entities.Enums;
using Tutorials.Data.Enums;

namespace Tutorials.Data.Entities
{
    public class Room
    {
        public Room()
        {
            Center=new Center();
            Teacher=new Teacher();
            students = new List<Student>();
            Subject=new Subject();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public TypeRoom TypeRoom { get; set; } 
        public int CurrentStudentNumber { get; set; }
        public int SizeRoom { get; set; }
        public double Duration { get; set; }
        
        public DayRoom DayOfWeeks { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Student> students { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        
    }
}