using System;

namespace DatingApp.API.DTO
{
    public class PhotosForDetailedDTO
    {
         public int id {get; set;}
        public string url {get; set;}
        public string description {get; set;}
        public DateTime dateAddedd {get; set;}
        public bool isMain {get; set;}
        
    }
}