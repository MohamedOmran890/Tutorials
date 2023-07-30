namespace Tutorials.Data.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Rooms=new List<Room>();
            Secretary=new List<Secretary>();
            Address=new Address();
        }
        public int TeacherId { get; set; }
        public string Bio { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Secretary> Secretary { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        

    }
}