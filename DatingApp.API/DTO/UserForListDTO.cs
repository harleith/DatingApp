using System;
using System.Collections.Generic;

namespace DatingApp.API.DTO
{
    public class UserForListDTO
    {
         public int id {get; set;}
        public string username { get; set; }
        public string gender {get; set;}
        public int age {get; set;}
        public string knownAs {get; set;}
        public DateTime created {get; set;}
        public DateTime lastActive {get; set;}
        public string city {get; set;}
        public string country {get; set;}
        public string photoUrl {get; set;}
        public ICollection<PhotosForDetailedDTO> Photos {get; set;}
    }
}