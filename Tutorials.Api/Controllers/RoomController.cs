using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks;
using AutoMapper;
using Tutorial.Infstructures.DTO;
using Tutorials.Data.Entities;
using Tutorials.Api.DTO;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetRoomBylevel/{LevelId:int}")]
        public async Task<IActionResult> GetRoomByLevel(int LevelId)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetRoomByLevelId(LevelId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("GetRoomByTeacher/{TeacherId:int}")]
        public async Task<IActionResult> GetRoomByTeacher(int TeacherId)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetRoomByTeacher(TeacherId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("GetRoomBySubject/{SubjectId:int}")]
        public async Task<IActionResult> GetRoomBySubject(int SubjectId)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetRoomBySubject(SubjectId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpGet("GetRoomByLevelAndSubject")]
        public async Task<IActionResult> GetRoomByLevelAndSubject(int levelId,int subjectId)
        {
            if (levelId < 0 || subjectId < 0)
                return NotFound("levelId or subjectId NOt Vaild");
          var rooms=_mapper.Map<IEnumerable<RoomDTO>>(await _unitOfWork.Room.GetRoomByLevelAndSubject(levelId, subjectId));
            return Ok(rooms);

        }

        [HttpGet("GetAllRoomBySubjectAndTeacherAndLevel/{SubjectId:int}/{TeacherId:int}/{LevelId:int}")]

        public async Task<IActionResult> GetRoomsBySubjectAndTeacherAndLevelthenFiltering(int SubjectId, int TeacherId, int LevelId, FilterDTO options, bool filterValue)
        {


            var rooms = _mapper.Map<IEnumerable<RoomDTO>>(await _unitOfWork.Room.GetRoomByTeacherAndSubjecAndLevel(SubjectId, TeacherId, LevelId));
            if (filterValue)
            {
                rooms = await _unitOfWork.Room.FilterRooms(rooms, options);

            }
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }

        [HttpGet("GetLocationRooms/{SubjectId:int}/{TeacherId:int}/{LevelId:int}")]

        public async Task<IActionResult> GetLocationRooms(int SubjectId, int TeacherId, int LevelId)
        {
            var rooms = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.GetLocationRooms(SubjectId, TeacherId, LevelId));
            if (rooms == null)
                return BadRequest();
            return Ok(rooms);
        }
        [HttpPost("FilterAllRooms/{SubjectId:int}/{City:alpha}/{LevelId:int}")]

        public async Task <IActionResult> FilterAllRooms (int SubjectId , int LevelId , string City , FilterDTO options )
        {
            var RoomsAfterFilter = _mapper.Map<List<RoomDTO>>(await _unitOfWork.Room.FilterRooms(filterDTO.rooms, filterDTO.typeRoom, filterDTO.Days, filterDTO.region, filterDTO.price));
            if (RoomsAfterFilter == null)
                return BadRequest();
            return Ok(RoomsAfterFilter);

        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreatRoomDto roomDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(roomDTO);
            var newRoom = _mapper.Map<Room>(roomDTO);
            var Room= await _unitOfWork.Room.Create(newRoom);
            if (Room != null)
                return Ok(Room);
            return BadRequest(Room);

        }
        [HttpPut]
        public async Task<IActionResult> EditRoom(int Id,RoomDTO roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(roomDto);
            var editRoom = _mapper.Map<Room>(roomDto);
            editRoom.Id = Id;
            var room =  _unitOfWork.Room.Update(Id,editRoom);
            if (room != null)
                return Ok(room);
            return BadRequest(room);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRoom(int Id)
        {
            if (Id < 0)
                return NotFound();
            var room=await _unitOfWork.Room.DeleteById(Id);
            if (room != null)
                return Ok(room);
            return BadRequest();
        }
        





    }
}
