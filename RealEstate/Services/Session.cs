using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace RealEstate.Services
{
    public class Session : ISession
    {
        protected readonly RealEstateContext _context;
        public Session(RealEstateContext context)
        {
            _context = context;
        }

        public async Task<JwtSecurityToken> Login(ViewModels.UserLogin user)
        {
            Models.User existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Login == user.Login);

            if (existingUser != null && (new PasswordHasher<ViewModels.UserLogin>().VerifyHashedPassword(user, existingUser.Password, user.Password)) == PasswordVerificationResult.Success)
            {
                return await CreateJWTToken(existingUser);
            }
            return null;
        }

        async Task<JwtSecurityToken> CreateJWTToken(Models.User user)
        {
            return new JwtSecurityToken(
                "me",
                "you",
                new[] { new Claim("userId", user.ID.ToString(), ClaimValueTypes.Integer64) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"))), SecurityAlgorithms.HmacSha256));
        }

    }
}
