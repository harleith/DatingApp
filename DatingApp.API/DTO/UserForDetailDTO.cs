using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.DTO
{
    public class UserForDetailDTO
    {
         public int id {get; set;}
        public string username { get; set; }
        public string gender {get; set;}
        public int Age {get; set;}
        public string knownAs {get; set;}
        public DateTime created {get; set;}
        public DateTime lastActive {get; set;}
        public string introduction {get; set;}
        public string lookingFor {get; set;}
        public string interest {get; set;}
        public string city {get; set;}
        public string country {get; set;}
        public string photoUrl {get; set;}
        public ICollection<Photo> photos {get; set;}
    }
}