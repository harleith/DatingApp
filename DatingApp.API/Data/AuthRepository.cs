using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Logic;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        

        private readonly DataContext _context;
       
       UserLogic userLogic = new UserLogic();

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(String username, String password)
        {
             

            var user = await _context.Users.FirstOrDefaultAsync(x => x.username == username);
            
            if (user == null)
            {
                return null;
            }
            
            bool valid = userLogic.VerifyPasswordHash(password, user.passwordHash, user.passwordSalt);

            if (!valid)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public async Task<User> Register(User modelUser, String password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            userLogic.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            modelUser.passwordHash = passwordHash;
            modelUser.passwordSalt = passwordSalt;

            await _context.Users.AddAsync(modelUser);
            await _context.SaveChangesAsync();

            return modelUser;
        }

    

        public async Task<bool> UserExists(String username)
        {
            
            bool check = await _context.Users.AnyAsync(x => x.username == username);

            if(check != true)
            {
                return false;
            }
            
            return true;
        }
    }
}