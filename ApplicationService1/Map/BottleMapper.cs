using ApplicationService.BottleRepository.ViewModels;
using AutoMapper;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Map
{
    public class BottleMapper : Profile
    {
        public BottleMapper()
        {
            CreateMap<Bottle, BottleInput>();
            CreateMap<BottleInput, Bottle>();
        }
    }
}
