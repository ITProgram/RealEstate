using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public interface ISession
    {
        Task<JwtSecurityToken> Login(ViewModels.UserLogin user);
        //Task<JwtSecurityToken> LogOut(ViewModels.UserLogin user);

    }
}
