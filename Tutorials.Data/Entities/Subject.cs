using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
          

           

        }
       public int Id { get; set; }
       public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
        


    }
}
