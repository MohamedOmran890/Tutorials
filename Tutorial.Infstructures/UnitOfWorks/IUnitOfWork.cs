using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        ITeacherRepository teachers { get; }
        ISubjectRepository Subjects { get; }
        IRoomRepository Room { get; }
        ILevelRepository Level { get; }
        IGenricRepository<Student> Students { get; }
        int Complete();
    }
}
