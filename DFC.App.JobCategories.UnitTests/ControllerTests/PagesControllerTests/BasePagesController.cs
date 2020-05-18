﻿using DFC.App.JobCategories.Controllers;
using DFC.App.JobCategories.Data.Models;
using DFC.App.JobCategories.PageService;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Net.Mime;

namespace DFC.App.JobCategories.UnitTests.ControllerTests.PagesControllerTests
{
    public class BasePagesController
    {
        public BasePagesController()
        {
            Logger = A.Fake<ILogger<PagesController>>();
            FakeJobCategoryContentPageService = A.Fake<IContentPageService<JobCategory>>();
            FakeMapper = A.Fake<AutoMapper.IMapper>();
        }

        public static IEnumerable<object[]> HtmlMediaTypes => new List<object[]>
        {
            new string[] { "*/*" },
            new string[] { MediaTypeNames.Text.Html },
        };

        public static IEnumerable<object[]> InvalidMediaTypes => new List<object[]>
        {
            new string[] { MediaTypeNames.Text.Plain },
        };

        public static IEnumerable<object[]> JsonMediaTypes => new List<object[]>
        {
            new string[] { MediaTypeNames.Application.Json },
        };

        protected ILogger<PagesController> Logger { get; }

        protected IContentPageService<JobCategory> FakeJobCategoryContentPageService { get; }

        protected IContentPageService<JobProfile> FakeJobProfileContentPageService { get; }

        protected AutoMapper.IMapper FakeMapper { get; }

        protected PagesController BuildPagesController(string mediaTypeName)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Headers[HeaderNames.Accept] = mediaTypeName;

            var controller = new PagesController(Logger, FakeJobCategoryContentPageService, FakeJobProfileContentPageService, FakeMapper)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                },
            };

            return controller;
        }
    }
}
