﻿using Microsoft.AspNetCore.Html;

namespace DFC.App.JobCategories.ViewModels
{
    public class BodyViewModel
    {
        public HtmlString Content { get; set; } = new HtmlString("Unknown content");
    }
}
