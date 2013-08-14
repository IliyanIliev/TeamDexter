using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.ASPNetWebAPI.Models
{
    public class AlbumModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public double Size { get; set; }
    }
}
