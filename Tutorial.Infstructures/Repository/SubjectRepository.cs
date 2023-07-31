using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.GenricRepository;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.Repository
{
    internal class SubjectRepository : GenricRepository<Subject>, ISubjectRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public SubjectRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }

        public async Task<IEnumerable<Subject>> GetSubjectByTeacher(int TeacherId)
        {
            return await _tutorialDbContext.Teacher_Subjects.Where(s => s.TeacherId==TeacherId).Select(s=>s.Subject).ToListAsync();
        }
}
}
