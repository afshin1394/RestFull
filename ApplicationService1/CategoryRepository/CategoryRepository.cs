using ApplicationService.CategoryRepository.ViewModels;
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
using Utilities.Extensions;

namespace ApplicationService.CategoryRepository
{
    public class CategoryRepository : IRepository<CategoryInput>
    {
        private readonly AppDBContext appDBContext;
        private readonly ILogger<CategoryInput> _logger;

        public CategoryRepository(AppDBContext appDBContext, ILogger<CategoryInput> logger)
        {
            this.appDBContext = appDBContext;
            _logger = logger;
        }

        public CategoryInput Add(CategoryInput t)
        {
            appDBContext.Add(ObjectMapper.Mapper.Map<CategoryInput, Category>(t));
            appDBContext.SaveChanges();

            return t;
        }

        public CategoryInput Delete(object guid)
        {
            var search = appDBContext.Categories.FirstOrDefault(e => e.CategoryGuid.Equals(guid));
            appDBContext.Remove(search);
            appDBContext.SaveChanges();
            return ObjectMapper.Mapper.Map<Category, CategoryInput>(search);
        }

        public async Task<IEnumerable<CategoryInput>> FindByID(object sectionId)
        {
            
            List<int> ids  = sectionId.getInts();
             

            List<CategoryInput> categoryInputs = new List<CategoryInput>();
            
            for(int i = 0; i<ids.Count; i++)
            {
                categoryInputs.AddRange(ObjectMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryInput>>(appDBContext.Categories.Where(e => e.CategorySection == ids.ElementAt(i))).ToList());
            }

            return  categoryInputs;

        }

        public async Task<IEnumerable<CategoryInput>> GetAll()
        {
            var result =  ObjectMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryInput>>(appDBContext.Categories.AsEnumerable());

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
