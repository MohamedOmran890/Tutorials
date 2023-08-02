
using Tutorials.Data.Enums;
namespace Tutorials.Data.Entities
{
    public class Address
    {
        
        public int Id { get; set; }
        public City  City { get; set; }
        public string Region { get; set; }
        public virtual Center Center { get; set; }
        public virtual Student Student { get; set; } 
    }
}