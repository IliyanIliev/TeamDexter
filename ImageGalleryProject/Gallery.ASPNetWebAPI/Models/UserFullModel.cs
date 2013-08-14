using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class UserFullModel : UserModel
    {
        public UserFullModel()
        {
            this.Galleries = new HashSet<GalleryModel>();
        }

        public string AuthCode { get; set; }

        public ICollection<GalleryModel> Galleries { get; set; }
    }
}