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
    public class TeacherRepository : GenricRepository<Teacher>, ITeacherRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public TeacherRepository(TutorialDbContext tutorialDbContext) : base(tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }

        public async Task<IEnumerable<Teacher>> GetByName(string Name)
        {
            return await _tutorialDbContext.Teachers.Where(N => N.User.FirstName.Contains(Name) || N.User.LastName.Contains(Name)).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByCity(string City)
        {
            return await _tutorialDbContext.Teachers.Where(c => c.Address.City == City).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByRegion(string Region)
        {
            return await _tutorialDbContext.Teachers.Where(c => c.Address.Region == Region).ToListAsync();
        }
    }
}
