﻿using DFC.App.JobCategories.Data.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DFC.App.JobCategories.PageService
{
    public interface IContentPageService
    {
        Task<bool> PingAsync();

        Task<IEnumerable<ContentPageModel>?> GetAllAsync();

        Task<ContentPageModel?> GetByIdAsync(Guid documentId);

        Task<ContentPageModel?> GetByNameAsync(string? canonicalName);

        Task<ContentPageModel?> GetByAlternativeNameAsync(string? alternativeName);

        Task<HttpStatusCode> UpsertAsync(ContentPageModel? contentPageModel);

        Task<bool> DeleteAsync(Guid documentId);
    }
}