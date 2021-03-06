using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User
    {
        public int id {get; set;}
        public string username { get; set; }
        public byte[] passwordHash {get; set;}
        public byte[] passwordSalt {get; set;}
        public string gender {get; set;}
        public DateTime dateOfBirth {get; set;}
        public string knownAs {get; set;}
        public DateTime created {get; set;}
        public DateTime lastActive {get; set;}
        public string introduction {get; set;}
        public string lookingFor {get; set;}
        public string interest {get; set;}
        public string city {get; set;}
        public string country {get; set;}
        public ICollection<Photo> photos {get; set;}
    }
}