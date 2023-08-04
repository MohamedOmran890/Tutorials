using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks; 
using AutoMapper ;
using Tutorials.Api.DTO ;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetRoomBylevel/{LevelId:int}")]
        public async Task<IActionResult> GetRoomByLevel(int LevelId)
        {
            var rooms=_mapper.Map<List<RoomDTO>>(await  _unitOfWork.Room.GetRoomByLevelId(LevelId)) ;
            if (rooms == null)
                return BadRequest();
                return Ok(rooms); 
        }
        [HttpGet("GetRoomByTeacher/{TeacherId:int}")]
        public async Task<IActionResult>GetRoomByTeacher(int TeacherId)
        {
            var rooms = _mapper.Map<List<RoomDTO>> (await _unitOfWork.Room.GetRoomByTeacher(TeacherId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("GetRoomBySubject/{SubjectId:int}")]
        public async Task <IActionResult> GetRoomBySubject(int SubjectId)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetRoomBySubject(SubjectId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("GetAllRoomBySubjectAndTeacherAndLevel/{SubjectId:int}/{TeacherId:int}/{LevelId:int}")]

        public async Task<IActionResult> GetRoomBySubjectAndTeacherAndLevel (int SubjectId , int TeacherId , int LevelId)
        {

            var rooms =  _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetRoomByTeacherAndSubjecAndLevel(SubjectId , TeacherId , LevelId)) ;
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }



    }
}
