using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
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

        public void Add(DareInput t)
        {
            appDBContext.Add(t);
            appDBContext.SaveChanges();
        }

        public void Delete(DareInput t)
        {
            var dare = appDBContext.Dares.FirstOrDefault(e => e.DareStr == t.DareStr);
            appDBContext.Remove(t);
            appDBContext.SaveChanges();
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

        public Boolean SaveChanges()
        {
            
            switch (appDBContext.SaveChanges())
            {
                case 1:
                    return true;
                default:
                    return false;
            }
        }
    }
}
