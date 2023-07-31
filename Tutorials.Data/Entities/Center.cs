using System.ComponentModel.DataAnnotations;

namespace Tutorials.Data.Entities
{
    public class Center
    {
        public Center()
        {
            Address=new Address();
            Rooms=new List<Room>();

        }
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

    }
}