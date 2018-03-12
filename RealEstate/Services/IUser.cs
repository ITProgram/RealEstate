using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public interface IUser
    {
        IEnumerable<Models.User> GetUsers();
        Task<Models.User> GetUserById(int userId);
        Task<Models.User> CreateUser(ViewModels.UserRegistration user);
        Task<Models.User> UpdateUser(ViewModels.UserProfile user, int userId);
        Task<Models.User> DeleteUser(int userId);
    }
}
