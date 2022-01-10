
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthDareGrpcService.Protos;

namespace TruthDareGrpcService.Map.Question
{
    public class QuestionMapper : Profile
    {
        
        public QuestionMapper()
        {
            CreateMap<EFDataAccessLibrary.Models.Question,TruthDareGrpcService.Protos.Question>();
            CreateMap<TruthDareGrpcService.Protos.InsertingQuestion, EFDataAccessLibrary.Models.Question>();
        }
    }
}
