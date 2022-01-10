
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TruthDareGrpcService.Map.Question
{
    public class QuestionMapper : Profile
    {
        
        public QuestionMapper()
        {
            CreateMap<QuestionInput, Protos.Question>();
            CreateMap<Protos.InsertingQuestion, QuestionInput>();

        }
    }
}
