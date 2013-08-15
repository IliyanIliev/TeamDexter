using Gallery.ASPNetWebAPI.Models;
using Gallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.ASPNetWebAPI.Repositories
{
    public class CommentsRepository
    {
        internal static IEnumerable<CommentModel> GetAll(string sessionKey)
        {

            var context = new GalleryContext();

            var result = context.Comments.Select(CommentModel.FromComment).ToList();

            return result;
        }

        public static void CreateComment(int? imageId, string text, int userId)
        {

            using (GalleryContext context = new GalleryContext())
            {
                var author = context.Users.Find(userId);
                var image = context.Images.Find(imageId);
                var dbComment = new Gallery.Models.Comment()
                {
                    Text=text,
                    Author=author,
                    Image = image
                };

                context.Comments.Add(dbComment);
                context.SaveChanges();
            }
        }
    }
}