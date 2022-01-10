using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Commons
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public void Add(T t);
        public void Delete(T t);
        public Task<IEnumerable<T>> FindByID(int id);
        public Boolean SaveChanges();

    }
}
