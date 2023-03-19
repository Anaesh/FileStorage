using System;
using FileStorage.Api.Business;
using FileStorage.Api.Business.Interfaces;
using FileStorage.Api.DTOs;
using FileStorage.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Api
{
    [ApiController]
    [Route("api/users")]
	public class UserController: ControllerBase
	{
        private readonly IUserBL _userBl;
        private readonly IUserBL _userBl1;
        private readonly IUserBL _userBl2;
        public UserController(IUserBL userBL, IUserBL userBL1, IUserBL userBL2)
        {
            _userBl = userBL;
            _userBl1 = userBL1;
            _userBl2 = userBL2;
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userBl.GetUsers();
        }

        [HttpPost]
        [ProducesResponseType((int)StatusCodes.Status201Created, Type = typeof(ObjectGuid))]
        public ActionResult<ObjectGuid> CreateUser([FromBody] CreateUserDto user)
        {
            var newUser = new User { Name = user.Name };
            newUser.Id = _userBl.CreateUser(newUser);
            return CreatedAtAction(nameof(GetUser), new { userId = newUser.Id }, new ObjectGuid { Id = newUser.Id });
        }

        [HttpGet("{userId}")]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        public ActionResult<User> GetUser(Guid userId)
        {
            return _userBl.GetUser(userId);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType((int)StatusCodes.Status404NotFound)]
        [ProducesResponseType((int)StatusCodes.Status200OK)]
        public ActionResult DeletUser(Guid userId)
        {
            _userBl.DeleteUser(userId);
            return Ok();
        }
    }
}

