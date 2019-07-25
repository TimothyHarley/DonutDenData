using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DonutDenData.Data;
using DonutDenData.Models;
using DonutDenData.Validators;

namespace DonutDenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookTypesController : ControllerBase
    {
        readonly CookTypeRepository _cookTypeRepository;
        readonly CookTypeRequestValidator _validator;

        public CookTypesController()
        {
            _cookTypeRepository = new CookTypeRepository();
            _validator = new CookTypeRequestValidator();
        }

        [HttpGet]
        public ActionResult GetAllCookTypes()
        {
            return Ok(_cookTypeRepository.GetAllCookTypes());
        }

        [HttpGet("{id}")]
        public ActionResult GetCookTypesByUser(int id)
        {
            return Ok(_cookTypeRepository.GetCookTypesByUser(id));
        }
        
        [HttpGet("ct-category/{id}")]
        public ActionResult GetCookTypeByCategory(int id)
        {
            return Ok(_cookTypeRepository.GetCookTypesByCategory(id));
        }

        [HttpPost]
        public ActionResult AddCookType(CreateCookTypeRequest createCookType)
        {
            if (!_validator.Validate(createCookType))
            {
                return BadRequest(new { error = "invalid cook type" });
            }
            var newCookType = _cookTypeRepository.AddCookType(createCookType);

            return Created($"api/cookTypes/{newCookType.Id}", newCookType);
        }
    }
}