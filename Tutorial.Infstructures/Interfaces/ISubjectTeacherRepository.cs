using Tutorials.Data.Entities;
using Tutorial.Infstructures.DTO;

namespace Tutorial.Infstructures.Interfaces
{
    public interface ISubjectTeacherRepository : IGenricRepository<SubjectTeacher>
    {
        public Task<IEnumerable<Level>> GetLevelsByTeacher_And_Subject(int SubjectId, int TeacherId);
        public Task<IEnumerable<Subject>> GetSubjectByTeacher(int TeacherId);
        public Task<IEnumerable<CenterDTO>> GetCentersByTeacher(int TeacherId );
        public Task<IEnumerable<LevelDTO>> GetLevelsbyTeacherAndCenterAndSubject(int TeacherId, int CenterId, int SubjectId);
        public Task<IEnumerable<SubjectDTO>> GetSubjectbyTeacherAndCenter(int TeacherId, int CenterId) ;






    }
}