﻿using System;

namespace DFC.App.JobCategories.MessageFunctionApp.Models
{
    public class ContentPageClientOptions
    {
        public Uri? BaseAddress { get; set; }

        public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);
    }
}