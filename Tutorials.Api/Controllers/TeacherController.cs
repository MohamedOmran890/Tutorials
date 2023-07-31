using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tutorial.Infstructures.Interfaces;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
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
            var teacher=await _teacherRepository.GetById(Id);
            if (teacher == null)
                return  NotFound();
            return Ok(teacher);
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string Name)
        {
            var teachers = await _teacherRepository.GetByName(Name);
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }
        [HttpGet("GetTeacherByCity")]
        public async Task<IActionResult> GetTeacherByCity([FromQuery]string City)
        {
            var teachers = await _teacherRepository.GetTeacherByCity(City);
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }

        [HttpGet("GetTeacherByRegion")]
        public async Task<IActionResult> GetTeacherByRegion([FromQuery] string Region)
        {
            var teachers = await _teacherRepository.GetTeacherByCity(Region);
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var teacher=await _teacherRepository.DeleteById(Id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);

        }

    }
}
