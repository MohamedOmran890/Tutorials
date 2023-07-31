using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.UnitOfWorks;
using Tutorials.Api.DTO;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherController(IUnitOfWork unitOfWork,IMapper mapper)
        {
           _unitOfWork=unitOfWork;
            _mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            //var teachers = _mapper.Map<IEnumerable<TeacherDto>>(await _unitOfWork.teachers.GetList());
            var teachers =await _unitOfWork.teachers.GetList();
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GtById(int Id)
        {
            var teacher=_mapper.Map<TeacherDto>(await _unitOfWork.teachers.GetById(Id));
            if (teacher == null)
                return  NotFound();
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
        public async Task<IActionResult> GetTeacherByCity([FromQuery]string City)
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
            var teacher=await _unitOfWork.teachers.DeleteById(Id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);

        }

    }
}
