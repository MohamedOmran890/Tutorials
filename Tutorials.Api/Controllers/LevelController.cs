using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks ;
using AutoMapper ;
using Tutorials.Data.Entities ;
using Microsoft.EntityFrameworkCore ;
using System.Linq;
namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LevelController (IUnitOfWork unitOfWork ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        [HttpGet("{SubjectId:int}/{TeacherId:int}")]
        public async Task<IActionResult> GetLevelsByTeacherAndSubject (int SubjectId , int TeacherId)
        {
            var Levels = await unitOfWork.SubjectsTeacher.GetLevelsByTeacher_And_Subject(SubjectId ,TeacherId);
            if (Levels == null)
                return NotFound();

            return Ok(Levels);


        }
    }
}
