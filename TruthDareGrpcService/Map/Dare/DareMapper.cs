using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace TruthDareGrpcService.Map.Dare
{
    public class DareMapper : Profile
    {
        public DareMapper()
        {
            CreateMap<EFDataAccessLibrary.Models.Dare, TruthDareGrpcService.Dare.Protos.DareModel>();
            CreateMap<TruthDareGrpcService.Dare.Protos.InsertingDare, EFDataAccessLibrary.Models.Dare>();
        }
    }
}
