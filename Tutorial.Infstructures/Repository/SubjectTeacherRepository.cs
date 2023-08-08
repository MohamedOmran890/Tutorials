using Tutorials.Data.Entities;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.GenricRepository;
using Tutorials.Data.Context;
using Tutorial.Infstructures.DTO;
using Microsoft.EntityFrameworkCore;
namespace Tutorial.Infstructures.Repository
{


    public class SubjectTeacherRepository : GenricRepository<SubjectTeacher>, ISubjectTeacherRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public SubjectTeacherRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }
        public async Task<IEnumerable<Level>> GetLevelsByTeacher_And_Subject(int SubjectId, int TeacherId)
        {

            return await _tutorialDbContext.Teacher_Subjects.Where(i => i.SubjectId == SubjectId && i.TeacherId == TeacherId).Select(i => i.Level).ToListAsync();
        }
        public async Task<IEnumerable<Subject>> GetSubjectByTeacher(int TeacherId)
        {
            return await _tutorialDbContext.Teacher_Subjects.Where(s => s.TeacherId == TeacherId).Select(s => s.Subject).ToListAsync();
        }
        public async Task<IEnumerable<CenterDTO>> GetCentersByTeacher(int TeacherId)
        {
            return await _tutorialDbContext.Teacher_Subjects
            .Where(s => s.TeacherId == TeacherId)
            .GroupBy(i => i.center)
            .Select(group => new CenterDTO
            {
                Name = group.Key.Name,
                Address = group.Key.Address,
                Id = group.Key.Id


            }).ToListAsync();


        }
        public async Task<IEnumerable<SubjectDTO>> GetSubjectbyTeacherAndCenter(int TeacherId, int CenterId)
        {
            return await _tutorialDbContext.Teacher_Subjects
            .Where(s => s.TeacherId == TeacherId && s.CenterId == CenterId)
            .GroupBy(i => i.Subject)
            .Select(group => new SubjectDTO
            {
                Name = group.Key.Name,
                Id = group.Key.Id


            }).ToListAsync();


        }
        public async Task<IEnumerable<LevelDTO>> GetLevelsbyTeacherAndCenterAndSubject(int TeacherId, int CenterId, int SubjectId)
        {
            return await _tutorialDbContext.Teacher_Subjects
            .Where(s => s.TeacherId == TeacherId && s.CenterId == CenterId && s.SubjectId == SubjectId)
            .GroupBy(i => i.Level)
            .Select(group => new LevelDTO
            {
                Name = group.Key.Name,
                Id = group.Key.Id


            }).ToListAsync();


        }


    }
}