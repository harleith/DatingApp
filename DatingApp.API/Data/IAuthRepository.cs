using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface  IAuthRepository
    {
        Task<User> Register (User modelUser, String password);
        
        Task<User> Login (String username, String password);

        Task<bool> UserExists (String username);

    }
}