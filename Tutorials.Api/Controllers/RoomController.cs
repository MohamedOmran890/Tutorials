using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        
        }
        [HttpGet("{LevelId}")]
        public IActionResult GetRoomByLevel(int LevelId)
        {
            var rooms=_unitOfWork.Room.GetRoomByLevelId(LevelId);
            if (rooms == null)
                return BadRequest();
                return Ok(rooms); 
        }
        [HttpGet("{TeacherId}")]
        public IActionResult GetRoomByTeacher(int TeacherId)
        {
            var rooms = _unitOfWork.Room.GetRoomByTeacher(TeacherId);
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("{SubjectId}")]
        public IActionResult GetRoomBySubject(int SubjectId)
        {
            var rooms = _unitOfWork.Room.GetRoomBySubject(SubjectId);
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }



    }
}
