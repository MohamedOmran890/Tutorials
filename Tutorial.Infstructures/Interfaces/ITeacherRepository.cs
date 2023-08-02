using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Interfaces
{
    public interface ITeacherRepository:IGenricRepository<Teacher>
    {
        public Task<IEnumerable<Teacher>> GetByName(string Name);
        public Task<IEnumerable<Teacher>> GetTeacherByCity(string Name);
        public Task<IEnumerable<Teacher>> GetTeacherByRegion(string Name);
        public Task<List<Teacher>> FilteringTeachersByCity(string CityID, string Name);


    }
}
