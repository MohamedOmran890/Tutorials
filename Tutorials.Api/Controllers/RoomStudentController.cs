using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks;
using Tutorials.Api.DTO;
using Tutorials.Data.Entities;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomStudentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult>JoinStudentForRoom(RoomStudentDto RoomStudent)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var roomStudent=_mapper.Map<RoomStudent>(RoomStudent);
            var Correct = await _unitOfWork.RoomStudent.JoinStudentForRoom(roomStudent);
            if (Correct != null)
                return Ok(RoomStudent);
            else
                return StatusCode(504, "Occured Error ");


        }

    }
}
