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
using Tutorials.Data.Enums; 
namespace Tutorial.Infstructures.Repository
{
    public class RoomRepository : GenricRepository<Room>, IRoomRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;
        public RoomRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }

        public async Task<IEnumerable<Room>> GetRoomByLevelId(int LevelId)
        {
            return await _tutorialDbContext.Rooms.Where(r => r.LevelId == LevelId).ToListAsync();
        }
        
        public async Task<IEnumerable<Room>> GetRoomByTeacher(int TeacherId)
        {
            return await _tutorialDbContext.Rooms.Where(r => r.TeacherId == TeacherId).ToListAsync();

        }
        public async Task<IEnumerable<Room>> GetRoomBySubject(int SubjectId)
        {
            return await _tutorialDbContext.Rooms.Where(r=>r.SubjectId==SubjectId).ToListAsync();

        }

        public  async Task<IEnumerable<Room>> GetRoomByTeacherAndSubjecAndLevel(int SubjectId , int TeacherId , int LevelId )
        {
            return await _tutorialDbContext.Rooms.Where(r=>r.SubjectId ==SubjectId&& r.TeacherId ==TeacherId && r.LevelId==LevelId).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetLocationRooms (int SubjectId , int TeacherId , int LevelId)
        {
            var rooms  = await GetRoomByTeacherAndSubjecAndLevel(SubjectId, TeacherId, LevelId);
            var regions = rooms.Select(i => i.Center.Address.Region);

            return await Task.FromResult(regions); ;
        }
               
        public async Task<IEnumerable<Room>> FilterRooms (List<Room> rooms  , int typeRoom  , List<int> days  , string region ,double price ) 
        {
            // client server can send zero if user dosesn't select 
             if (typeRoom != 0)
             {
                rooms = rooms.Where(room => (int) room.TypeRoom == typeRoom).ToList();
             }
             if (days  != null )
             {
                int All = 0;
                foreach(int day in days )
                {
                    All =All |day  ;

                }
                // ?? why to list ??
                rooms  =  rooms.Where(room=>((int)room.DayOfWeeks & All) != 0).ToList();

             }
             // query string
             if (!string.IsNullOrWhiteSpace(region))
             {
                rooms =  rooms.Where(room=>room.Center.Address.Region== region).ToList();
    

             }
             if (price != 0)
             {
                rooms = rooms.Where(room=>room.Price <= price ).ToList();
             }
             return  rooms ; 

        }

        public async Task<IEnumerable<Room>> GetRoomByLevelAndSubject(int levelId, int subjectId)
        {
            return await _tutorialDbContext.Rooms.Where(r => r.LevelId == levelId && r.SubjectId == subjectId).ToListAsync();

        }
    }
}
