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
    public class MenuItemsController : ControllerBase
    {
        readonly MenuItemRepository _menuItemRepository;

        public MenuItemsController()
        {
            _menuItemRepository = new MenuItemRepository();
        }

        [HttpGet]
        public ActionResult GetMenu()
        {
            return Ok(_menuItemRepository.GetMenu());
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleMenuItem(int id)
        {
            return Ok(_menuItemRepository.GetSingleMenuItem(id));
        }

        [HttpGet("category/{id}")]
        public ActionResult GetMenuByCategory(int id)
        {
            return Ok(_menuItemRepository.GetMenuByCategory(id));
        }
    }
}