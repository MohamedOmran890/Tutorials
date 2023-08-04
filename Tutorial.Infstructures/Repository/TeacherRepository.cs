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
using Tutorials.Data.Enums ;

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
            return await _tutorialDbContext.Teachers.AsNoTracking().Where(N => N.User.FirstName.Contains(Name) || N.User.LastName.Contains(Name)).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByCity(string City)
        {
            return await _tutorialDbContext.Teachers.AsNoTracking().Where(c => c.Address.City ==City).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeacherByRegion(string Region)
        {
            return await _tutorialDbContext.Teachers.AsNoTracking().Where(c => c.Address.Region == Region).ToListAsync();
        }

        public async Task<List<Teacher>> FilteringTeachersByCity (string CityID , string Name)
        {
            var teachers  = _tutorialDbContext.Teachers as IQueryable<Teacher>;
            if (!string.IsNullOrWhiteSpace(CityID))
            {
                teachers = teachers.Where(i=>i.Address.City == CityID);
            }
            
            if (!string.IsNullOrWhiteSpace(Name))
            {
                teachers = teachers.Where(i=>i.User.FirstName.Contains(Name )) ;

            }
            return await teachers.ToListAsync();

        }
    }
}
