namespace Tutorials.Data.Entities
{
    public class Level
    {
        public Level()
        {
            Subject=new Subject();
            Students=new List<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}