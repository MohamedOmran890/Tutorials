using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Infstructures.Interfaces;
using Tutorials.Data.Context;

namespace Tutorial.Infstructures.GenricRepository
{
    public class GenricRepository<T> : IGenricRepository<T> where T : class
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public GenricRepository(TutorialDbContext tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }
        public async Task<T?> GetById(int Id)
        {
            return await _tutorialDbContext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T?>> GetList()
        {
            return await _tutorialDbContext.Set<T>().ToListAsync();

            throw new NotImplementedException();
        }

        public  T? Update(int Id, T NewObj)
        {
            var OldObj=GetById(Id);
             _tutorialDbContext.Set<T>().Update(NewObj);
            _tutorialDbContext.SaveChanges();
            return NewObj;
        }
        public async Task<T?> Create(T NewObj)
        {
             await _tutorialDbContext.Set<T>().AddAsync(NewObj);
            _tutorialDbContext.SaveChanges();
            return NewObj;
        }

        public async Task<T?> DeleteById(int Id)
        {
            var Obj = await GetById(Id);

            if (Obj is not null)
                _tutorialDbContext.Set<T>().Remove(Obj);
            _tutorialDbContext.SaveChanges();
            return null;

        }

      
    }
}
