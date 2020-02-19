using System;
using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed  
    {
        public static void SeedUsers(DataContext context)
        {
                if (!context.Users.Any())
                {
                    var userData =  System.IO.File.ReadAllText("Data/UserSeedData.json");
                    var users =  JsonConvert.DeserializeObject<List<User>>(userData);
                    foreach(var item in users)
                    {
                        byte[] passwordHash;
                        byte[] passwordSalt;
                        CreatePasswordHash("Password", out passwordHash, out passwordSalt);

                        item.passwordHash = passwordHash;
                        item.passwordSalt = passwordSalt;
                        item.username = item.username.ToLower();
                         context.Users.Add(item);
                    }

                     context.SaveChanges();

                }
        }

         public static void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var encrypt =  new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = encrypt.Key;
            passwordHash = encrypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

    }
    }
}