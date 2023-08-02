using Tutorials.Data.Entities; 
using Tutorial.Infstructures.Interfaces ;
using Tutorial.Infstructures.GenricRepository ;
using Tutorials.Data.Context ;
using Microsoft.EntityFrameworkCore ;
namespace Tutorial.Infstructures.Repository {


    public class SubjectTeacherRepository : GenricRepository<SubjectTeacher> , ISubjectTeacherRepository 
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public SubjectTeacherRepository (TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
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

    }
}