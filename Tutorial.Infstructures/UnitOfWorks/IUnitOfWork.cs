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
        //IGenricRepository<Student> Students { get; }
        //IGenricRepository<Teacher> teachers { get; }
        int Complete();
    }
}
