using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class CommentFullModel : CommentModel
    {
        public User Author { get; set; }

    }
}