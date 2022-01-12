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
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<QuestionInput> _repository;

        public QuestionController(ILogger<QuestionController> logger, IRepository<QuestionInput> repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [Produces("application/json")]
        [HttpGet("Questions")]
        public IActionResult Index()
        {
            var response = _repository.GetAll();
            return Ok(response);
        }
        [Produces("application/json")]
        [HttpPost("InsertQuestion")]
        public IActionResult InsertQuestion([FromBody] QuestionInput questionInput)
        {
            var question = _repository.Add(questionInput);
            if (question != null)
            {
                return Created(Request.Path.Value, Ok(_repository.Add(questionInput)));
            }

            return BadRequest();
        }

        [Produces("application/json")]
        [HttpPost("DeleteQuestion")]
        public IActionResult DeleteQuestion([FromQuery (Name = "Guid")] Guid id) 
        {
            var question = _repository.Delete(id);
            if (question != null)
            {
                return Created(Request.Path.Value, question);
            }
            return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
