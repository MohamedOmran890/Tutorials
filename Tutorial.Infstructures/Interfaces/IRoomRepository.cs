using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Interfaces
{
    public interface IRoomRepository:IGenricRepository<Room>
    {
        public IEnumerable<Room> GetRoomByLevelId(int LevelId);
        public Task<IEnumerable<Room>> GetRoomByTeacher(int TeacherId);
        public Task<IEnumerable<Room>> GetRoomBySubject(int SubjectId);

    }
}
