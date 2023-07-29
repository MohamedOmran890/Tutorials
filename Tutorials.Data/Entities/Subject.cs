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
            Level = new Level();

            Rooms=new List<Room>();

        }
       public int Id { get; set; }
       public string Name { get; set; }
       public Level Level { get; set; }
        public ICollection<Room> Rooms { get; set; }


    }
}
