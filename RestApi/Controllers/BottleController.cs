using ApplicationService.BottleRepository.ViewModels;
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
    public class BottleController : Controller
    {
        private readonly ILogger<BottleController> _logger;
        private readonly IRepository<BottleInput> _repository;

        public BottleController(ILogger<BottleController> logger, IRepository<BottleInput> repository)
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

    }
}
