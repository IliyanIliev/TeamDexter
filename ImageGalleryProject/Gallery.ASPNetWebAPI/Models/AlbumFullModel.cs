using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class AlbumFullModel : AlbumModel
    {
        public AlbumFullModel()
        {
            this.Albums = new HashSet<AlbumModel>();
            this.Images = new HashSet<ImageModel>();
        }

        public ICollection<AlbumModel> Albums { get; set; }

        public ICollection<ImageModel> Images { get; set; }
    }
}