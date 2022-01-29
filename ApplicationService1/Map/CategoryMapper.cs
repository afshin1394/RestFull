using ApplicationService.CategoryRepository.ViewModels;
using AutoMapper;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Map
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
      

  
                CreateMap<Category, CategoryInput>();

                CreateMap<CategoryInput, Category>();
        }
    }
}
