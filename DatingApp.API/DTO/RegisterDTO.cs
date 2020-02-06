using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTO
{
    public class RegisterDTO
    {
        [Required]
        public String username {get; set;} 
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "You Must Specify Password Between 5 and 10 character")]
        public String password {get; set;}
    }
}