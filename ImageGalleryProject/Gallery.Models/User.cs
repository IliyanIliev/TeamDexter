using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gallery.Models
{
    public class User
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        [StringLength(50)]
        public string AuthCode { get; set; }

        public string Password { get; set; }

        public virtual Gallery Gallery { get; set; }
    }
}
