using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
    }
}