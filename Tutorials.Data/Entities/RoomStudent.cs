using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    internal class RoomStudent
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
