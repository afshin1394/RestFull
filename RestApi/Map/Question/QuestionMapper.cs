
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
            CreateMap<QuestionInput, Protos.Question>().ForAllOtherMembers(x => x.Ignore());
            CreateMap<IEnumerable<QuestionInput>,IEnumerable<Protos.Question>>().ForAllOtherMembers(x => x.Ignore());
            CreateMap<Protos.InsertingQuestion, QuestionInput>().ForAllOtherMembers(x => x.Ignore());
            CreateMap<IEnumerable<Protos.InsertingQuestion>,IEnumerable<QuestionInput>>().ForAllOtherMembers(x => x.Ignore());

        }
    }
}
