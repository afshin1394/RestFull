using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Map
{
    public class QuestionMapper : Profile
    {

        public QuestionMapper()
        {
            CreateMap<Question, QuestionInput>();
                
            CreateMap<QuestionInput,Question>();
        }
    }
}
