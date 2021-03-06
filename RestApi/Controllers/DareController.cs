using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    public class DareController : Controller
    {
        private readonly ILogger<DareController> _logger;
        private readonly IRepository<DareInput> _repository;

        public DareController(ILogger<DareController> logger, IRepository<DareInput> repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [Produces("application/json")]
        [HttpGet("GetAll")]
        public IActionResult index()
        {
            var response = _repository.GetAll();
            return Ok(response);
        }

        [Produces("application/json")]
        [HttpPost("InsertDare")]
        public IActionResult InsertDare([FromBody] DareInput dareInput)
        {
            var dare = _repository.Add(dareInput);
            if (dare != null)
            {
                return Created(Request.Path.Value, Ok(_repository.Add(dareInput)));
            }

            return BadRequest();
        }

        [Produces("application/json")]
        [HttpPost("DeleteDare")]
        public IActionResult DeleteQuestion([FromQuery(Name = "Guid")] Guid id)
        {
            var dare = _repository.Delete(id);
            if (dare != null)
            {
                return Created(Request.Path.Value, dare);
            }
            return BadRequest();
        }
    }
}
