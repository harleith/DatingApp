using System;

namespace DatingApp.API.Logic
{
    public class UserLogic
    {
        public void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var encrypt =  new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = encrypt.Key;
            passwordHash = encrypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

    }



        public bool VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var valid =  new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
           var passwordValid = valid.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           for (int i = 0; i < passwordValid.Length; i++)
           {
               if(passwordValid[i] != passwordHash[i])
               {
                 return false;
               }
           }
        }
        return true;
    }


    }
}
