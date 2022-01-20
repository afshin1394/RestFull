using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Commons
{
    public interface IRepository<T>  where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public T Add(T t);
        public T Delete(object t);
        public Task<IEnumerable<T>> FindByID(int id);
        public bool SaveChanges();

    }
}
