using Microsoft.AspNetCore.Mvc;
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
    public class Room_StudentRepository : GenricRepository<RoomStudent>, IRoom_StudentRepository
    {
        private readonly TutorialDbContext _tutorialDbContext1;
        public Room_StudentRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext1 = tutorialDbContext;
        }
        public async Task<RoomStudent> JoinStudentForRoom(RoomStudent roomStudent)
        {
             await _tutorialDbContext1.RoomStudents.AddAsync(roomStudent);
             var affectRow=await _tutorialDbContext1.SaveChangesAsync();
            if(affectRow>0)
            return roomStudent;
            return null;

        }
    }
}
