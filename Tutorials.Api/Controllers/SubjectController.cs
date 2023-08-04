using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Infstructures.UnitOfWorks;

namespace Tutorials.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public SubjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetSubjectByTeacher(int TeacherId)
        {
            var subjects= await _unitOfWork.SubjectsTeacher.GetSubjectByTeacher(TeacherId);

            return Ok(subjects);
        }

       
    }
}
