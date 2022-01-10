using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using AutoMapper;
using TruthDareGrpcService.Dare.Protos;

namespace TruthDareGrpcService.Map.Dare
{
    public class DareMapper : Profile
    {
        public DareMapper()
        {
            CreateMap<DareInput, DareModel>();
            CreateMap<InsertingDare, DareInput>();
        }
    }
}
