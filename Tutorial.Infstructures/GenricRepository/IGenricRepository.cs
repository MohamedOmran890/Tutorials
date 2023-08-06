using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Infstructures.Interfaces
{
    public interface IGenricRepository<T> where T : class
    {
        public Task<T?> GetById(int Id);
        public Task<List<T?>> GetList();
        public Task<T?> Update(int Id,T NewObj);
        public Task<T?> Create(T NewObj);
        public Task<T?> DeleteById(int Id);

    }
}
