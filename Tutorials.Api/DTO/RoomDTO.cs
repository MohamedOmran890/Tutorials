using Tutorials.Data.Enums ;


namespace Tutorials.Api.DTO {

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
        public int CenterId { get; set; }
    
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public int LevelId { get; set; }



    }
}