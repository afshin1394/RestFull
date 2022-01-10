using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.QuestionR
{
    public class QuestionRepository : IRepository<QuestionInput>
    {
        private readonly AppDBContext appDBContext;
        private readonly ILogger<QuestionRepository> _logger;
        private readonly IMapper mapper;


        public QuestionRepository(AppDBContext appDBContext,ILogger<QuestionRepository> logger, IMapper mapper)
        {
            this.appDBContext = appDBContext;
            this._logger = logger;
            this.mapper = mapper;
        }

        public void Add(QuestionInput t)
        {
            
            
            appDBContext.Add(t);
            appDBContext.SaveChanges();
        }

        public void Delete(QuestionInput t)
        {

            
            var search = appDBContext.Questions.FirstOrDefault(e => e.QuestionStr == t.QuestionStr);
            appDBContext.Remove(search);
            appDBContext.SaveChanges();
        }

        public async Task<IEnumerable<QuestionInput>> FindByID(int id)
        {

            return mapper.Map< IEnumerable<Question>, IEnumerable<QuestionInput>>(appDBContext.Questions.Where(e => e.CategoryID == id)); 
             
        
        }

        public async Task<IEnumerable<QuestionInput>> GetAll()
        {
            var result = mapper.Map<IEnumerable<Question>, IEnumerable<QuestionInput>>(appDBContext.Questions.ToList());
      
            return result;

        }

        public bool SaveChanges()
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
