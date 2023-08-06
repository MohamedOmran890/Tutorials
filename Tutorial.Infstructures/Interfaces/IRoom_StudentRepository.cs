using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Interfaces
{
    public interface IRoom_StudentRepository : IGenricRepository<RoomStudent>
    {
        public Task<RoomStudent> JoinStudentForRoom(RoomStudent roomStudent);

    }
}
