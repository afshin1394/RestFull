using ApplicationService.Map;
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationService.QuestionR
{
    public class QuestionRepository : IRepository<QuestionInput>
    {
        private readonly AppDBContext appDBContext;
        private readonly ILogger<QuestionRepository> _logger;
        private readonly IMapper _mapper;
        private bool disposedValue;

        public QuestionRepository(AppDBContext appDBContext,ILogger<QuestionRepository> logger, IMapper mapper)
        {
            this.appDBContext = appDBContext;
            _logger = logger;
            _mapper = mapper;
        }

        public QuestionInput Add(QuestionInput t)
        {
            
            appDBContext.Add(ObjectMapper.Mapper.Map<QuestionInput,Question>(t));
            appDBContext.SaveChanges();
            
            return t;
        }

        public QuestionInput Delete(object guid)
        {
            //for (int i = 0; i < appDBContext.Questions.ToList().Count(); i++)
            //{
            //    Console.WriteLine(appDBContext.Questions.ToList().ElementAt(i).QuestionGuid);
            //    if (appDBContext.Questions.ToList().ElementAt(i).QuestionGuid.Equals(guid))
            //    {
            //        Console.WriteLine("found");
            //        appDBContext.Remove(appDBContext.Questions.ToList().ElementAt(i));
            //        appDBContext.SaveChanges();
            //        return ObjectMapper.Mapper.Map<Question, QuestionInput>(appDBContext.Questions.ToList().ElementAt(i));
            //    }
            //}
            var search = appDBContext.Questions.FirstOrDefault(e => e.QuestionGuid.Equals(guid));
            appDBContext.Remove(search);
            appDBContext.SaveChanges();
            return ObjectMapper.Mapper.Map<Question, QuestionInput> (search);

        }

    
        public async Task<IEnumerable<QuestionInput>> FindByID(object id)
        {
            return ObjectMapper.Mapper.Map< IEnumerable<Question>, IEnumerable<QuestionInput>>(appDBContext.Questions.Where(e => e.CategoryID == (int)id)); 
        }

        public async Task<IEnumerable<QuestionInput>> GetAll()
        {
            var result =  ObjectMapper.Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionInput>>(appDBContext.Questions.AsEnumerable());
      
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
