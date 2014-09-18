﻿namespace DNG.Web.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using DNG.Data;
    using DNG.Models;

    public class ImagesController : BaseApiController
    {
        //// Poor man's dependency inversion
        //// Switched to Ninject
        //public ImageController()
        //    : this(new DngData(new DngDbContext()))
        //{
        //}

        public ImagesController(IDngData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            // Used to create the tables not associated with users 
            this.data.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "somevalue";
        }
    }
}