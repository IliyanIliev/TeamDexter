using Gallery.ASPNetWebAPI.Models;
using Gallery.Models;
using Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public CommentFullModel Get(int Id)
        {
            var comment = this.unitOfWork.CommentsRepository.Get(Id);

            CommentFullModel fullComment = CommentFullModel.CreateComment(comment);

            return fullComment;
        }

        public HttpResponseMessage Post([FromBody] CommentFullModel fullComment)
        {
            var comment = fullComment.CreateCommment();

            this.unitOfWork.CommentsRepository.Add(comment);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + comment.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public HttpResponseMessage Put(int Id, [FromBody]CommentFullModel fullComment)
        {
            var comment = fullComment.CreateCommment();

            this.unitOfWork.CommentsRepository.Update(Id, comment);

            HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.OK);
            message.Headers.Location =
                new Uri(this.Request.RequestUri + comment.ID.ToString(CultureInfo.InvariantCulture));

            return message;
        }

        public void Delete(int Id)
        {
            this.unitOfWork.CommentsRepository.Delete(Id);
        }
    }
}
