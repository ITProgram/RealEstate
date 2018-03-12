using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RealEstate.Controllers
{
    [Produces("application/json")]
    [Route("api/Sessions")]
    public class SessionsController : Controller
    {
        private readonly RealEstateContext _context;
        private readonly Services.ISession _sessionService;

        public SessionsController(RealEstateContext context, Services.ISession sessionService)
        {
            _context = context;
            _sessionService = sessionService;
        }

        [AllowAnonymous]
        [HttpPost]//logiin
        public async Task<IActionResult> Login([FromBody]ViewModels.UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                Dictionary<string, List<string>> errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList());
                return BadRequest(new { errors });
            }

            JwtSecurityToken jwtSecurityToken = await _sessionService.Login(user);
            if (jwtSecurityToken == null)
            {
                return Unauthorized();
            }

            Response.Headers.Add("Authorization", new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
            
            return Ok();
            //return Ok(new
            //{
            //    access_token = new JwtSecurityTokenHandler().WriteToken(token),
            //    expires_in = DateTime.Now.AddMinutes(30),
            //    token_type = "bearer"
            //});
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            
            foreach (var cookie in Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
            return Ok();

        }
        //[AllowAnonymous]
        //[HttpPost]//register
        //public async Task<IActionResult> Logina([FromBody]User user)
        //{
        //    if (!ModelState.IsValid) return BadRequest("Token failed to generate");
        //    var userIdentified = _context.Users.FirstOrDefault(u => u.ID == user.ID);
        //    if (userIdentified == null)
        //    {
        //        return Unauthorized();
        //    }
        //    user = userIdentified;

        //    //Add Claims
        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
        //    new Claim(JwtRegisteredClaimNames.Sub, "data"),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //};

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT_Secret"])); //Secret
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken("me",
        //        "you",
        //        claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);
        //    Response.Cookies.Append("Authorization", new JwtSecurityTokenHandler().WriteToken(token));
        //    return Ok(new
        //    {
        //        access_token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expires_in = DateTime.Now.AddMinutes(30),
        //        token_type = "bearer"
        //    });
        //}
    }
}