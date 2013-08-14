using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public virtual User Author { get; set; }
    }
}
