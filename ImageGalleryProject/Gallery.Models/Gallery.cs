﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Models
{
    public class Gallery
    {
        public Gallery()
        {
            this.Albums = new HashSet<Album>();
            this.Images = new HashSet<Image>();
        }

        public int ID { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}