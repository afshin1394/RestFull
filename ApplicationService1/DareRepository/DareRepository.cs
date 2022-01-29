using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using ApplicationService.Map;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.DareRepository
{
    public class DareRepository : IRepository<DareInput>
    {
        private readonly AppDBContext appDBContext;
        private readonly ILogger<DareInput> _logger;

        public DareRepository(AppDBContext appDBContext, ILogger<DareInput> logger)
        {
            this.appDBContext = appDBContext;
            _logger = logger;
        }

        public DareInput Add(DareInput t)
        {
            appDBContext.Add(ObjectMapper.Mapper.Map<DareInput, Dare>(t));
            appDBContext.SaveChanges();

            return t;
        }

        public DareInput Delete(object guid)
        {
            var search = appDBContext.Dares.FirstOrDefault(e => e.DareGuid.Equals(guid));
            appDBContext.Remove(search);
            appDBContext.SaveChanges();
            return ObjectMapper.Mapper.Map<Dare, DareInput>(search);
        }

        public async Task<IEnumerable<DareInput>> FindByID(object id)
        {
            return ObjectMapper.Mapper.Map<IEnumerable<Dare>, IEnumerable<DareInput>>(appDBContext.Dares.Where(e => e.CategoryID == (int)id));
        }

        public async Task<IEnumerable<DareInput>> GetAll()
        {
            var result =  ObjectMapper.Mapper.Map<IEnumerable<Dare>, IEnumerable<DareInput>>(appDBContext.Dares.AsEnumerable());

            return  result;
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
