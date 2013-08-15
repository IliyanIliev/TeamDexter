using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Linq.Expressions;


namespace Gallery.ASPNetWebAPI.Models
{

    [DataContract]
    public class AlbumPreviewModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }


        public static Expression<Func<Album, AlbumPreviewModel>> FromAlbum
        {
            get
            {
                return x => new AlbumPreviewModel
                {
                    Title = x.Title,
                };
            }
        }
    }

    public class AlbumModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public double Size { get; set; }

        internal static AlbumModel CreateModel(Gallery.Models.Album album)
        {
            return new AlbumModel()
            {
                Title = album.Title,
                DateCreated = album.DateCreated,
                DateModified = album.DateModified,
                ID = album.ID,
                Size = album.Size
            };
        }

        public Gallery.Models.Album CreateAlbum()
        {
            return new Album()
            {
                ID = this.ID,
                DateCreated = this.DateCreated,
                DateModified = this.DateModified,
                Size = this.Size,
                Title = this.Title,
            };
        }
    }

}