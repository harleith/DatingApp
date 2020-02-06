using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTO
{
    public class UserLoginDto
    {
        [Required]
        public String username {get; set;}

        [Required]
        public String Password {get; set;}
    }
}