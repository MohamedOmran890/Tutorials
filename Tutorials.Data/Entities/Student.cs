using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    public class Student
    {
        
        public int StudentId { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; } 
        public virtual ICollection<RoomStudent> RoomStudents { get; set; } 
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
