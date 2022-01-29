using ApplicationService.CategoryRepository.ViewModels;
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
    public class CategoryController : Controller
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly IRepository<CategoryInput> _repository;

        public CategoryController(ILogger<CategoryController> logger, IRepository<CategoryInput> repository)
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
        [HttpPost("InsertCategory")]
        public IActionResult InsertDare([FromBody] CategoryInput categoryInput)
        {
            var dare = _repository.Add(categoryInput);
            if (dare != null)
            {
                return Created(Request.Path.Value, Ok(_repository.Add(categoryInput)));
            }

            return BadRequest();
        }

        [Produces("application/json")]
        [HttpPost("DeleteCategory")]
        public IActionResult DeleteQuestion([FromQuery(Name = "Guid")] Guid id)
        {
            var category = _repository.Delete(id);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [Produces("application/json")]
        [HttpGet("GetBySectionID")]
        public IActionResult GetBySection([FromQuery(Name = "Section")] string sectionId)
        {
            var response = _repository.FindByID(sectionId);
            return Ok(response);
        }
    }
}
