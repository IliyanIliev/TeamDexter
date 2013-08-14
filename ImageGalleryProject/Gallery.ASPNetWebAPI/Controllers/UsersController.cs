using Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gallery.Models;
using Gallery.Repositories;
using System.Globalization;
using Gallery.ASPNetWebAPI.Models;

namespace Gallery.ASPNetWebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UnitOfWork unitOfWork;

        public UsersController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public UsersController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public HttpResponseMessage PostUser(User user)
        {
            this.unitOfWork.UsersRepository.Add(user);
            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + user.ID.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        public ICollection<UserModel> GetAll()
        {
            var userEntities = unitOfWork.UsersRepository.All();
            var userModels = from userEntity in userEntities
                            select new UserModel()
                            {
                                ID = userEntity.ID,
                                FirstName = userEntity.FirstName,
                                LastName = userEntity.LastName,
                                Username = userEntity.Username
                            };

            return userModels.ToList();

        }

        public User Get(int id)
        {
            return unitOfWork.UsersRepository.Get(id);
        }
    }
}
