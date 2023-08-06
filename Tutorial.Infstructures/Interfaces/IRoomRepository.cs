using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Interfaces
{
    public interface IRoomRepository : IGenricRepository<Room>
    {
        public Task<IEnumerable<Room>> GetRoomByLevelId(int LevelId);
        public Task<IEnumerable<Room>> GetRoomByTeacher(int TeacherId);
        public Task<IEnumerable<Room>> GetRoomBySubject(int SubjectId);
        public Task<IEnumerable<Room>> GetRoomByTeacherAndSubjecAndLevel(int SubjectId, int TeacherId, int LevelId);
        public Task<IEnumerable<string>> GetLocationRooms(int SubjectId, int TeacherId, int LevelId);
        public Task<IEnumerable<Room>> FilterRooms(List<Room> rooms, int typeRoom, List<int> days, string region, double price);
        Task<IEnumerable<Room>> GetRoomByLevelAndSubject(int levelId, int subjectId);


    }
}
