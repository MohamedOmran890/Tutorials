namespace Tutorials.Data.Entities
{
    public class Teacher:User
    {
        public Teacher()
        {
            Rooms=new List<Room>();
            Secretary=new List<Secretary>();
            Address=new Address();
        }
        public int Id { get; set; }
        public string Bio { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Secretary> Secretary { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        

    }
}