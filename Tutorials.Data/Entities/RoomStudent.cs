using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    public class RoomStudent
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
