﻿using DFC.Content.Pkg.Netcore.Data.Contracts;
using DFC.Content.Pkg.Netcore.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.JobCategories.Data.Models.API
{
    [ExcludeFromCodeCoverage]
    public class JobProfileApiResponse : BaseContentItemModel, IBaseContentItemModel
    {
        [JsonProperty("skos__prefLabel")]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public new IList<IBaseContentItemModel> ContentItems { get; set; } = new List<IBaseContentItemModel>();
    }
}
