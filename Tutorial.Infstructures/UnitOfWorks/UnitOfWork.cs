using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.GenricRepository;
using Tutorial.Infstructures.Interfaces;
using Tutorial.Infstructures.Repository;
using Tutorials.Data.Context;
using Tutorials.Data.Entities;

namespace Tutorial.Infstructures.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly TutorialDbContext _tutorialDbContext;
        public IGenricRepository<Student> Students { get; private set; }
        public ITeacherRepository teachers { get; private set; }
        public ISubjectRepository Subjects { get; private set; }
        public ILevelRepository Level { get; private set; }

        public IRoomRepository Room { get; private set; }

        public UnitOfWork(TutorialDbContext tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
            Students = new GenricRepository<Student>(_tutorialDbContext);
            teachers = new  TeacherRepository(_tutorialDbContext);
            Subjects = new  SubjectRepository(_tutorialDbContext);
            Room= new RoomRepository(_tutorialDbContext);
            Level = new LevelRepository(_tutorialDbContext);

        }
        public int Complete()
        {
            return _tutorialDbContext.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
