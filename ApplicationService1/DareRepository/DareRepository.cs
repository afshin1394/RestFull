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
        private readonly ILogger<Dare> _logger;
        private readonly IMapper _mapper;

        public DareRepository(AppDBContext appDBContext, ILogger<Dare> logger, IMapper mapper)
        {
            this.appDBContext = appDBContext;
            _logger = logger;
            _mapper = mapper;
        }

        public DareInput Add(DareInput t)
        {
            appDBContext.Add(t);
            appDBContext.SaveChanges();
            return t;
        }

        public DareInput Delete(object t)
        {
            var dare = appDBContext.Dares.FirstOrDefault(e => e.DareGuid.ToString() == t.ToString());
            appDBContext.Remove(t);
            appDBContext.SaveChanges();

            return ObjectMapper.Mapper.Map<Dare,DareInput>(dare);
        }

        public async Task<IEnumerable<DareInput>> FindByID(int id)
        {
            return _mapper.Map<IEnumerable<Dare>, IEnumerable<DareInput>>(appDBContext.Dares.Where(e => e.CategoryID == id));
        }

        public async Task<IEnumerable<DareInput>> GetAll()
        {
            var result = _mapper.Map<IEnumerable<Dare>, IEnumerable<DareInput>>(appDBContext.Dares.ToList());

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
