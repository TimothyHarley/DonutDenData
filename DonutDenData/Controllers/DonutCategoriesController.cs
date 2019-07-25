using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DonutDenData.Data;

namespace DonutDenData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonutCategoriesController : ControllerBase
    {
        readonly DonutCategoryRepository _donutCategoryRepository;

        public DonutCategoriesController()
        {
            _donutCategoryRepository = new DonutCategoryRepository();
        }

        [HttpGet]
        public ActionResult GetAllDonutCategories()
        {
            return Ok(_donutCategoryRepository.GetAllDonutCategories());
        }

        [HttpGet]
        public ActionResult GetDonutCategoryById(int id)
        {
            return Ok(_donutCategoryRepository.GetDonutCategoryById(id));
        }
    }
}