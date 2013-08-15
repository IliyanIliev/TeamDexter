using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gallery.ASPNetWebAPI.Models;
using Gallery.Data;

namespace Gallery.ASPNetWebAPI.Repositories
{
    public class GalleryRepository
    {
        internal static IEnumerable<GalleryModel> GetAll(string sessionKey)
        {

                var context = new GalleryContext();
                var result = context.Galleries.Select(GalleryModel.FromGallery).ToList();

                return result;     
        }

        public static void CreateGallery(string name, string sessionKey)
        {

            using (GalleryContext context = new GalleryContext())
            {
                var dbGallery = new Gallery.Models.Gallery()
                {
                    Name = name
                };
                
                var userId = context.Users.Where(u=>u.SessionKey==sessionKey).FirstOrDefault().ID;
                context.Users.Find(userId).Galleries.Add(dbGallery);
                context.SaveChanges();
            }
        }




    }
}