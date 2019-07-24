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
    public class UsersController : ControllerBase
    {
        readonly UsersRepository _usersRepository;
        readonly UsersRequestValidator _validator;

        public UsersController()
        {
            _usersRepository = new UsersRepository();
            _validator = new UsersRequestValidator();
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_usersRepository.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleUser(int id)
        {
            return Ok(_usersRepository.GetSingleUser(id));
        }

        [HttpPost]
        public ActionResult AddUser(CreateUserRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "Missing information.  Please fill out the whole form." });
            }
            var newUser = _usersRepository.AddUser(createRequest);

            return Created($"api/users/{newUser.Id}", newUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, Users userToUpdate)
        {
            if (id != userToUpdate.Id)
            {
                return BadRequest(new { error = "There was an error in your update request." });
            }
            var updatedUser = _usersRepository.UpdateUser(userToUpdate);

            return Ok(updatedUser);
        }

        [HttpPut("delete-user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            _usersRepository.DeleteUser(id);

            return NoContent();
        }
    }
}