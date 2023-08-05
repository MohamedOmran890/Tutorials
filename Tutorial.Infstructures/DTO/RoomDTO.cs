using System.Net.Http.Headers;
using Tutorials.Data.Enums ;
using Tutorials.Data.Entities ;
namespace Tutorial.Infstructures.DTO
{

    public class RoomDTO  {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime Time { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public int CurrentStudentNumber { get; set; }
        public int SizeRoom { get; set; }
        public double Duration { get; set; }


        public DayRoom DayOfWeeks { get; set; }
        
        public string Region {get; set;}
            
        public string TeacherName {get; set;}

        public string SubjectName {get; set;}

        public string levelName {get; set;}



    }
}