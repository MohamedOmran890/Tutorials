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
        public virtual Center Center { get; set; }
        public virtual Student Student { get; set; }
    }
}