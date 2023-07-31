using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials.Data.Entities
{
    public class SubjectTeacher
    {
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public  int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
