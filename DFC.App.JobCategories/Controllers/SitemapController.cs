﻿using DFC.App.JobCategories.Extensions;
using DFC.App.JobCategories.Models;
using DFC.App.JobCategories.PageService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DFC.App.JobCategories.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ILogger<SitemapController> logger;
        private readonly IContentPageService contentPageService;

        public SitemapController(ILogger<SitemapController> logger, IContentPageService contentPageService)
        {
            this.logger = logger;
            this.contentPageService = contentPageService;
        }

        [HttpGet]
        [Route("/sitemap.xml")]
        public async Task<ContentResult?> Sitemap()
        {
            try
            {
                logger.LogInformation("Generating Sitemap");

                var sitemapUrlPrefix = $"{Request.GetBaseAddress()}{PagesController.RegistrationPath}/";
                var sitemap = new Sitemap();

                // add the defaults
                sitemap.Add(new SitemapLocation
                {
                    Url = $"{sitemapUrlPrefix}",
                    Priority = 1,
                });

                var contentPageModels = await contentPageService.GetAllAsync().ConfigureAwait(false);

                if (contentPageModels != null)
                {
                    var contentPageModelsList = contentPageModels.ToList();

                    if (contentPageModelsList.Any())
                    {
                        var sitemapContentPageModels = contentPageModelsList
                             .Where(w => w.IncludeInSitemap)
                             .OrderBy(o => o.CanonicalName);

                        foreach (var contentPageModel in sitemapContentPageModels)
                        {
                            sitemap.Add(new SitemapLocation
                            {
                                Url = $"{sitemapUrlPrefix}{contentPageModel.CanonicalName}",
                                Priority = 1,
                            });
                        }
                    }
                }

                // extract the sitemap
                var xmlString = sitemap.WriteSitemapToString();

                logger.LogInformation("Generated Sitemap");

                return Content(xmlString, MediaTypeNames.Application.Xml);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{nameof(Sitemap)}: {ex.Message}");
            }

            return default;
        }
    }
}