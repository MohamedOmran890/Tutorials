using System.Collections;
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
using Tutorial.Infstructures.DTO ;
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

            IQueryable<Room> query = _tutorialDbContext.Rooms;

            if (SubjectId != 0)
            {
                query = query.Where(room => room.SubjectId == SubjectId);
            }

            if (LevelId != 0)
            {
                query = query.Where(room => room.LevelId == LevelId);
            }

            if (TeacherId != 0)
            {
                query = query.Where(room => room.TeacherId == LevelId);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetLocationRooms (int SubjectId , int TeacherId , int LevelId)
        {
            var rooms  = await GetRoomByTeacherAndSubjecAndLevel(SubjectId, TeacherId, LevelId);
            var regions = rooms.Select(i => i.Center.Address.Region);

            return await Task.FromResult(regions); ;
        }
               
        public async Task<IEnumerable<RoomDTO>> FilterSpecificRooms (IEnumerable<RoomDTO> rooms  , FilterDTO options ) 
        {
            // client server can send zero if user dosesn't select 
             if (options.TypeRoom  != TypeRoom.notype)
             {
                rooms = rooms.Where(room =>  room.TypeRoom == options.TypeRoom);
             }
             if (options.Days  != null )
             {
                int All = 0;
                foreach(int day in  options.Days )
                {
                    All =All |day  ;

                }
                // ?? why to list ??
                rooms  =  rooms.Where(room=>((int)room.DayOfWeeks & All) != 0);

             }
             // query string
             if (!string.IsNullOrEmpty(options.Region))
             {
                rooms =  rooms.Where(room=>room.Region == options.Region);
    

             }
             if (options.Price != 0)
             {
                rooms = rooms.Where(room=>room.Price <= options.Price );
             }
             return  rooms ; 

        }


        public async Task<IEnumerable<Room>> FilterAllgroups  (int SubjectId ,int LevelId , string  City , FilterDTO options  )
        {

            IQueryable<Room> query = _tutorialDbContext.Rooms;

            if (SubjectId != 0)
            {
                query = query.Where(room => room.SubjectId == SubjectId);
            }

            if (LevelId != 0)
            {
                query = query.Where(room => room.LevelId == LevelId);
            }

            if (City != null )
            {
                query = query.Where(room =>room.Center.Address.City == City);
            }

            if (options.TypeRoom != TypeRoom.notype)
            {
                query = query.Where(room => room.TypeRoom == options.TypeRoom);
            }
            if (options.Days != null)
            {
                int All = 0;
                foreach (int day in options.Days)
                {
                    All = All | day;

                }
                // ?? why to list ??
                query = query.Where(room => ((int)room.DayOfWeeks & All) != 0) ;

            }
            // query string
            if (!string.IsNullOrEmpty(options.Region))
            {
                query = query.Where(room => room.Center.Address.Region== options.Region);


            }
            if (options.Price != 0)
            {
                query = query.Where(room => room.Price <= options.Price);
            }


            if (options.SubjectId != 0)
            {
                query = query.Where(room => room.SubjectId == SubjectId);
            }

            if (options.LevelId != 0)
            {
                query = query.Where(room => room.LevelId == LevelId);
            }

            if (options.City != null)
            {
                query = query.Where(room => room.Center.Address.City == City);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomByLevelAndSubject(int levelId, int subjectId)
        {
            return await _tutorialDbContext.Rooms.Where(r => r.LevelId == levelId && r.SubjectId == subjectId).ToListAsync();

        }
    }
}
