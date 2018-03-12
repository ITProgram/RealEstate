using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace RealEstate.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUser _userService;

        public UsersController(IUser userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<ViewModels.User> GetUsers()
        {
            return _userService.GetUsers()
               .Select(user => new ViewModels.User
               {
                   ID = user.ID,
                   Login = user.Login,
                   Email = user.Email
               });
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            Models.User user = await _userService.GetUserById(id);// _context.Users.SingleOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }


            if (User?.FindFirst("userId")!=null
                && (int.Parse(User?.FindFirst("userId")?.Value)).Equals(id))
            {
                return Ok(new ViewModels.User
                {
                    ID = user.ID,
                    Login = user.Login,
                    Email = user.Email
                });
            }
            return Ok(new ViewModels.UserPublicInfo
            {
                ID = user.ID,
                Login = user.Login
            });
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] ViewModels.UserProfile user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!(int.Parse(User?.FindFirst("userId")?.Value)).Equals(id))
            {
                return Unauthorized();
            }

            Models.User updatedUser = await _userService.UpdateUser(user, id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new ViewModels.User
            {
                ID = updatedUser.ID,
                Email = updatedUser.Email,
                Login = updatedUser.Login
            });
            //_context.Entry(user).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }
        [AllowAnonymous]
        [HttpPost]// POST: api/Users
        public async Task<IActionResult> PostUser([FromBody] ViewModels.UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Models.User createdUser = await _userService.CreateUser(user);
            return Ok(new ViewModels.User() { ID = createdUser.ID, Login = createdUser.Login, Email = createdUser.Email });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!(int.Parse(User?.FindFirst("userId")?.Value)).Equals(id))
            {
                return Unauthorized();
            }
            Models.User deletedUser = await _userService.DeleteUser(id);

            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(new ViewModels.User
            {
                ID = deletedUser.ID,
                Login = deletedUser.Login,
                Email = deletedUser.Email
            });
        }
    }
}   