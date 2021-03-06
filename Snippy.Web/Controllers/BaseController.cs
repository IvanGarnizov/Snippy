﻿namespace Snippy.Web.Controllers
{
    using System.Web.Mvc;

    using Data.UnitOfWork;

    public class BaseController : Controller
    {
        public BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        protected ISnippyData Data { get; set; }
    }
}