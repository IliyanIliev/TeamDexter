using Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gallery.Models;
using System.Globalization;
using Gallery.ASPNetWebAPI.Models;


namespace Gallery.ASPNetWebAPI.Controllers
{
    public class AlbumsController : BaseApiController
    {
        /*
                {
                   "username": "Dodo",
                   "nickname": "Doncho Minkov",
                   "authCode": "6fa9133efe05348e430bd5a4585b595f0cb6cba3"
                }
                */
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateAlbum([FromBody]AlbumModel album, string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                AlbumRepository.CreateAlbum(album.Title);
                string title = string.Empty;
                return new AlbumModel()
                {
                    Title = title,
                };
            });
            return responseMsg;

        }
        [HttpGet]
        [ActionName("get")]

        public HttpResponseMessage PreviewAlbums()
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var previewAlbums = AlbumRepository.GetAllAlbums();
                  return previewAlbums;
            });
            return responseMsg;
        }


    }
}


/*






       [HttpGet]
       [ActionName("all")]

        public HttpResponseMessage PreviewUsers()
        {
            var responseMsg = this.PerformOperation(() =>
                {
                    var previewUsers = UsersRepository.GetAllUsers();
                    return previewUsers;
                });
            return responseMsg;
        }

        //[HttpGet]
        //[ActionName("scores")]
        //public HttpResponseMessage GetAllUsers(string sessionKey)
        //{
        //    var responseMsg = this.PerformOperation(() =>
        //    {
        //        UsersRepository.LoginUser(sessionKey);
        //        IEnumerable<UserScore> users = UsersRepository.GetAllUsers();

        //        return users;
        //    });
        //    return responseMsg;
        //}
    }
}
    */




