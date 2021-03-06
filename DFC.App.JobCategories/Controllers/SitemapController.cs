﻿using DFC.App.JobCategories.Data.Models;
using DFC.App.JobCategories.Extensions;
using DFC.App.JobCategories.Models;
using DFC.App.JobCategories.PageService;
using DFC.Compui.Cosmos.Contracts;
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
        private readonly IDocumentService<JobCategory> documentService;

        public SitemapController(ILogger<SitemapController> logger, IDocumentService<JobCategory> documentService)
        {
            this.logger = logger;
            this.documentService = documentService;
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

                var contentPageModels = await documentService.GetAllAsync().ConfigureAwait(false);

                if (contentPageModels != null)
                {
                    var contentPageModelsList = contentPageModels.ToList();

                    if (contentPageModelsList.Any())
                    {
                        var sitemapContentPageModels = contentPageModelsList
                             .Where(w => w.IncludeInSitemap.HasValue && w.IncludeInSitemap.Value)
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