using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        public int id {get; set;}
        public string url {get; set;}
        public string description {get; set;}
        public DateTime dateAddedd {get; set;}
        public bool isMain {get; set;}
        public User user {get; set;}
        public int userId {get; set;}
    }
}