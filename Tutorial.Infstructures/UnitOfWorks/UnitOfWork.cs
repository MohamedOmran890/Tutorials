using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.GenricRepository;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly TutorialDbContext _tutorialDbContext;
        public IGenricRepository<Student> Students { get; private set; }
        public IGenricRepository<Teacher> teachers { get; private set; }



        public UnitOfWork(TutorialDbContext tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
            Students = new GenricRepository<Student>(_tutorialDbContext);
            teachers = new GenricRepository<Teacher>(_tutorialDbContext);

        }
        public int Complete()
        {
            return _tutorialDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _tutorialDbContext.Dispose() ;
        }
    }
}
