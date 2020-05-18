﻿using DFC.App.JobCategories.Data.Models;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.JobCategories.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class DocumentViewModel
    {
        public BreadcrumbViewModel? Breadcrumb { get; set; }

        [Display(Name = "Document Id")]
        public Guid? DocumentId { get; set; }

        [Display(Name = "Canonical Name")]
        public string? CanonicalName { get; set; }

        [Display(Name = "Breadcrumb Title")]
        public string? BreadcrumbTitle { get; set; }

        [Display(Name = "Include In SiteMap")]
        public bool IncludeInSitemap { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Keywords { get; set; }

        public HtmlString? Content { get; set; }

        [Display(Name = "Last Reviewed")]
        public DateTime LastReviewed { get; set; }

        [Display(Name = "Alternative Names")]
        public IList<string>? AlternativeNames { get; set; }

        public BodyViewModel? BodyViewModel { get; set; }

        public IEnumerable<JobProfile>? JobProfiles { get; set; }
    }
}
