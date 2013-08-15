using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class ImageModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime? DateUploaded { get; set; }

        public string Url { get; set; }

        public double Size { get; set; }

        public static Expression<Func<Image, ImageModel>> FromImage
        {
            get
            {
                return x => new ImageModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    DateUploaded = x.DateUploaded,
                    Url = x.Url,
                };
            }
        }

        public static ImageModel CreateModel(Image image)
        {
            return new ImageModel
            {
                ID = image.ID,
                DateUploaded = image.DateUploaded,
                Title = image.Title,
                Url = image.Url
            };
        }

        public Image CreateImage()
        {
            return new Image
            {
                ID = this.ID,
                Title = this.Title,
                Url = this.Url,
                DateUploaded = this.DateUploaded
            };
        }
    }
}