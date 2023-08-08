using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.UnitOfWorks;
using Tutorial.Infstructures.DTO;
using Tutorials.Data.Context;
using System.Web;
using Microsoft.AspNetCore.Authorization;


namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    

        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
    
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = _mapper.Map<IEnumerable<TeacherDto>>(await _unitOfWork.teachers.GetListAsNoTracking());
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var teacher = _mapper.Map<TeacherDto>(await _unitOfWork.teachers.GetById(Id));
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string Name)
        {
            var teachers = _mapper.Map<TeacherDto>(await _unitOfWork.teachers.GetByName(Name));
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }
        [HttpGet("GetTeacherByCity")]
        public async Task<IActionResult> GetTeacherByCity([FromQuery] string City)
        {
            var teachers = _mapper.Map<TeacherDto>(await _unitOfWork.teachers.GetTeacherByCity(City));
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }

        [HttpGet("GetTeacherByRegion")]
        public async Task<IActionResult> GetTeacherByRegion([FromQuery] string Region)
        {
            var teachers = _mapper.Map<TeacherDto>(await _unitOfWork.teachers.GetTeacherByCity(Region));
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var teacher = await _unitOfWork.teachers.DeleteById(Id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);

        }
        [HttpGet("FilteringTeacher")]
        public async Task<IActionResult> FilteringTeachersByCity([FromQuery] string CityID, [FromQuery] string Name)
        {
            if (string.IsNullOrWhiteSpace(CityID) && string.IsNullOrWhiteSpace(Name))
            {
                return RedirectToAction("GetAll");
            }
            return Ok(_mapper.Map<IEnumerable<TeacherCartDto>>(await _unitOfWork.teachers.FilteringTeachersByCity(CityID, Name)));

        }
        [HttpGet("check")]

        public async Task<IActionResult> check()
        {

            if (User.Identity.IsAuthenticated)
            {
                // User is authenticated
                return Ok("Authenticated!");
            }
            else
            {
                // User is not authenticated
                return Unauthorized("Not Authenticated!");
            }
        }


    }
}
