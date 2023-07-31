using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.GenricRepository;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Repository
{
    public class RoomRepository : GenricRepository<Room>, IRoomRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;
        public RoomRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }

        public IEnumerable<Room> GetRoomByLevelId(int LevelId)
        {
            return _tutorialDbContext.Rooms.Where(r => r.LevelId == LevelId).ToList();
        }
        
        public async Task<IEnumerable<Room>> GetRoomByTeacher(int TeacherId)
        {
            return await _tutorialDbContext.Rooms.Where(r => r.TeacherId == TeacherId).ToListAsync();

        }
        public async Task<IEnumerable<Room>> GetRoomBySubject(int SubjectId)
        {
            return await _tutorialDbContext.Rooms.Where(r=>r.SubjectId==SubjectId).ToListAsync();

        }

    }
}
