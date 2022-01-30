using ApplicationService.BottleRepository.ViewModels;
using ApplicationService.Map;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BottleRepository
{
    public class BottleRepository : IRepository<BottleInput>
    {
        private readonly AppDBContext appDBContext;
        private readonly ILogger<BottleInput> _logger;

        public BottleRepository(AppDBContext appDBContext, ILogger<BottleInput> logger)
        {
            this.appDBContext = appDBContext;
            _logger = logger;
        }

        public BottleInput Add(BottleInput t)
        {
            appDBContext.Add(ObjectMapper.Mapper.Map<BottleInput, Bottle>(t));
            appDBContext.SaveChanges();

            return t;
        }

        public BottleInput Delete(object guid)
        {
            var search = appDBContext.bottles.FirstOrDefault(e => e.BottleGuid.Equals(guid));
            appDBContext.Remove(search);
            appDBContext.SaveChanges();
            return ObjectMapper.Mapper.Map<Bottle, BottleInput>(search);
        }

        public async Task<IEnumerable<BottleInput>> FindByID(object id)
        {
            return  ObjectMapper.Mapper.Map<IEnumerable<Bottle>, IEnumerable<BottleInput>>(appDBContext.bottles.Where(e => e.CategoryId == (int)id));
        }

        public async Task<IEnumerable<BottleInput>> GetAll()
        {
            var result = ObjectMapper.Mapper.Map<IEnumerable<Bottle>, IEnumerable<BottleInput>>(appDBContext.bottles.AsEnumerable());

            return result;
        }

        public bool SaveChanges()
        {
            switch (appDBContext.SaveChanges())
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }
    }
}
