namespace Tutorials.Data.Entities
{
    public class Secretary:User
    {
        public Secretary()
        {
            Teacher = new Teacher();
        }
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}