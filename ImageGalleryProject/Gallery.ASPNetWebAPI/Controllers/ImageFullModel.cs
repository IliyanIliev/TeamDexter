using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class ImageFullModel : ImageModel
    {
        public ImageFullModel()
        {
            this.Comments = new HashSet<CommentModel>();
        }
        public ICollection<CommentModel> Comments { get; set; }
    }
}