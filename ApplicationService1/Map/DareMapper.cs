using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Map
{
    public class DareMapper : Profile
    {
        public DareMapper()
        {
            CreateMap< Dare, DareInput>();
        }
    }
}
