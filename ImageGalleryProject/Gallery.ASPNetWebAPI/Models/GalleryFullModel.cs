using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    [DataContract]
    public class GalleryFullModel : GalleryModel
    {
        public GalleryFullModel()
        {
            this.Albums = new HashSet<AlbumModel>();
            this.Images = new HashSet<ImageModel>();
        }

        [DataMember(Name = "albums")]
        public ICollection<AlbumModel> Albums { get; set; }

        [DataMember(Name = "images")]
        public ICollection<ImageModel> Images { get; set; }
    }
}