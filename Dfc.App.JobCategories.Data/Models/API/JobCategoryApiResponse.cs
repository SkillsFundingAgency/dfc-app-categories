﻿using DFC.App.JobCategories.Data.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.App.JobCategories.Data.Models.API
{
    public class JobCategoryApiResponse
    {
        public JobCategoryApiResponse()
        {
            Links = new List<Link>();
        }

        [JsonProperty("skos__prefLabel")]
        public string Title { get; set; }

        [JsonProperty("ncs__WebsiteURI")]
        public Uri WebsiteUri { get; set; }

        [JsonProperty("ncs__Description")]
        public string Description { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("_links")]
        [JsonConverter(typeof(DynamicKeyJsonConverter))]
        public IEnumerable<Link> Links { get; set; }
    }
}