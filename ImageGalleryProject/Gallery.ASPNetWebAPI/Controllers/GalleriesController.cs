﻿using Gallery.ASPNetWebAPI.Repositories;
using Gallery.Data;
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
    public class GalleriesController : BaseApiController
    {
        //private UnitOfWork unitOfWork;

        //public GalleriesController()
        //{
        //    this.unitOfWork = new UnitOfWork();
        //}

        //public GalleriesController(UnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        //public IEnumerable<Gallery.Models.Gallery> GetAll()
        //{
        //    return this.unitOfWork.GalleriesRepository.All().ToList();
        //}

        //public Gallery.Models.Gallery Get(int Id)
        //{
        //    return this.unitOfWork.GalleriesRepository.Get(Id);
        //}

        //public HttpResponseMessage Post([FromBody] Gallery.Models.Gallery gallery)
        //{
        //    this.unitOfWork.GalleriesRepository.Add(gallery);

        //    HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.Created);
        //    message.Headers.Location =
        //        new Uri(this.Request.RequestUri + gallery.ID.ToString(CultureInfo.InvariantCulture));

        //    return message;
        //}

        //public HttpResponseMessage Put(int Id, Gallery.Models.Gallery gallery)
        //{
        //    this.unitOfWork.GalleriesRepository.Update(Id, gallery);

        //    HttpResponseMessage message = this.Request.CreateResponse(HttpStatusCode.OK);
        //    message.Headers.Location =
        //        new Uri(this.Request.RequestUri + gallery.ID.ToString(CultureInfo.InvariantCulture));

        //    return message;
        //}

        //public void Delete(int Id)
        //{
        //    this.unitOfWork.GalleriesRepository.Delete(Id);
        //}

        [HttpGet]
        [ActionName("get")]
        public HttpResponseMessage GetGalleries(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var previewGalleries = GalleryRepository.GetAll(sessionKey);
                return previewGalleries;
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("getSingle")]
        public HttpResponseMessage GetGallery([FromBody]string username)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var gallery = GalleryRepository.GetSingle(username);
                return gallery;
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage AddGallery(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                GalleryRepository.CreateGallery("deffault", sessionKey);

            });
            return responseMsg;
        }
    }
}
