using Gallery.ASPNetWebAPI.Models;
using Gallery.Models;
using Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gallery.ASPNetWebAPI.Controllers
{
    public class CommentsController : ApiController
    {
        private UnitOfWork unitOfWork;

        public CommentsController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public CommentsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CommentModel> GetAll()
        {
            return this.unitOfWork.CommentsRepository.All()
                .Select(CommentModel.FromComment).ToList();
        }
    }
}
