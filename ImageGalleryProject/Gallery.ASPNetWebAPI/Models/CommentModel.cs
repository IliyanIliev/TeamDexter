using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Gallery.ASPNetWebAPI.Models
{
    public class CommentModel
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return x => new CommentModel
                {
                    ID = x.ID,
                    Text = x.Text
                };
            }
        }

        public static CommentModel CreateModel(Comment comment)
        {
            return new CommentModel
            {
                ID = comment.ID,
                Text = comment.Text
            };
        }

        public Comment CreateCommment()
        {
            return new Comment 
            { 
                ID = this.ID,
                Text = this.Text
            };
        }
    }
}