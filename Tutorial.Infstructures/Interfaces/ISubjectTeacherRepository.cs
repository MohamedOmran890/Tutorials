using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Interfaces
{
    public interface ISubjectTeacherRepository : IGenricRepository<SubjectTeacher>
    {
        public Task<IEnumerable<Level>> GetLevelsByTeacher_And_Subject(int SubjectId, int TeacherId);
        public Task<IEnumerable<Subject>> GetSubjectByTeacher(int TeacherId);



    }
}