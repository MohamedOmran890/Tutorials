using Tutorials.Data.Enums;

namespace Tutorial.Infstructures.DTO 
{
    public class CreatRoomDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime Time { get; set; }
        public TypeRoom TypeRoom { get; set; }
        public int SizeRoom { get; set; }
        public double Duration { get; set; }

        public DayRoom DayOfWeeks { get; set; }
        public int CenterId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public int LevelId { get; set; }
    }
}
