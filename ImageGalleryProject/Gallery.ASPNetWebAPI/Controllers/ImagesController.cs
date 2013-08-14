using Gallery.ASPNetWebAPI.Models;
using Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gallery.ASPNetWebAPI.Controllers
{
    public class ImagesController : ApiController
    {
        private UnitOfWork unitOfWork;

        public ImagesController()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public ImagesController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ImageModel> GetAll()
        {
            return this.unitOfWork.ImagesRepository.All()
                .Select(ImageModel.FromImage).ToList();
        }

        public 
    }
}
