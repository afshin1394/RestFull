using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Models;
using RestApi.Models.QuestionViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<DareInput> _repository;

        public QuestionController(ILogger<QuestionController> logger, IRepository<DareInput> repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [Produces("application/json")]
        [HttpGet("GetAll")]
        public IActionResult Index()
        {
            var response  = _repository.GetAll();
            return Ok(Json(response));
        }

        [Produces("application/json")]
        [HttpPost]
        public IActionResult InsertQuestion([FromBody] DareInput dareInput)
        {
            _repository.Add(dareInput);
            bool done = _repository.SaveChanges();
            return Ok(done);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
