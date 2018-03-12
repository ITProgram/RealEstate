using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace RealEstate.Services
{
    public class User : IUser
    {
        protected readonly RealEstateContext _context;
        public User(RealEstateContext context)
        {
            _context = context;
        }

        public IEnumerable<Models.User> GetUsers()
        {
            return _context.Users;
        }
        public async Task<Models.User> GetUserById(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.ID == userId);
        }
        public async Task<Models.User> CreateUser(ViewModels.UserRegistration user)
        {
            Models.User creatingUser = new Models.User
            {
                Login = user.Login,
                Email = user.Email
            };
            creatingUser.Password = new PasswordHasher<Models.User>().HashPassword(creatingUser, user.Password);
            EntityEntry<Models.User> createdUser = await _context.Users.AddAsync(creatingUser);
            await _context.SaveChangesAsync();
            return createdUser.Entity;
        }
        public async Task<Models.User> UpdateUser(ViewModels.UserProfile user, int userId)
        {
            Models.User existingUser = await _context.Users.SingleOrDefaultAsync(u => u.ID == userId);
            if (!String.IsNullOrEmpty(user.Login)) existingUser.Login = user.Login;
            if (!String.IsNullOrEmpty(user.Email)) existingUser.Email = user.Email;
            if (!String.IsNullOrEmpty(user.Password))
                existingUser.Password = new PasswordHasher<Models.User>()
                    .HashPassword(existingUser, user.Password);
            
            //_context.Entry(existingUser).CurrentValues.SetValues(user);

            EntityEntry<Models.User> updatedUser =  _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
        public async Task<Models.User> DeleteUser(int userId)
        {
            Models.User existingUser = await _context.Users.SingleOrDefaultAsync(user => user.ID == userId);
            if (existingUser == null)
            {
                return null;
            }
            EntityEntry<Models.User> deletingUser = _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return deletingUser.Entity;
        }

    }
}
