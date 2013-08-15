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
<<<<<<< HEAD

        [DataMember(Name = "albums")]
        public IEnumerable<AlbumModel> Albums { get; set; }

        [DataMember(Name = "images")]
        public IEnumerable<ImageModel> Images { get; set; }
=======

        [DataMember(Name = "albums")]
        public ICollection<AlbumModel> Albums { get; set; }

        [DataMember(Name = "images")]
        public ICollection<ImageModel> Images { get; set; }
>>>>>>> 12f1d196f7acd4bf771e2fd8bd0d5158a7ed7b71
    }
}