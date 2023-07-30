namespace Tutorials.Data.Entities
{
    public class Address
    {
        public Address()
        {
            Student=new Student();
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public Center Center { get; set; }
        public Student Student { get; set; }
    }
}