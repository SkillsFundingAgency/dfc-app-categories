﻿using AutoMapper;
using DFC.App.JobCategories.Data.Models;
using DFC.App.JobCategories.ViewModels;
using Microsoft.AspNetCore.Html;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.JobCategories.AutoMapperProfiles
{
    [ExcludeFromCodeCoverage]
    public class ContentPageModelProfile : Profile
    {
        public ContentPageModelProfile()
        {
            CreateMap<ContentPageModel, BodyViewModel>()
                .ForMember(d => d.Content, s => s.MapFrom(a => new HtmlString(a.Content)))
                ;

            CreateMap<ContentPageModel, DocumentViewModel>()
                .ForMember(d => d.Breadcrumb, s => s.Ignore())
                .ForMember(d => d.Content, s => s.MapFrom(a => new HtmlString(a.Content)))
                .ForMember(d => d.Title, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Title + " | Explore careers | National Careers Service" : null))
                .ForMember(d => d.Description, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Description : null))
                .ForMember(d => d.Keywords, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Keywords : null))
                .ForMember(d => d.BodyViewModel, s => s.MapFrom(a => a))
                ;

            CreateMap<ContentPageModel, HtmlHeadViewModel>()
                .ForMember(d => d.CanonicalUrl, s => s.Ignore())
                .ForMember(d => d.Title, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Title + " | Explore careers | National Careers Service" : null))
                .ForMember(d => d.Description, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Description : null))
                .ForMember(d => d.Keywords, s => s.MapFrom(a => a.MetaTags != null ? a.MetaTags.Keywords : null))
                ;

            CreateMap<ContentPageModel, IndexDocumentViewModel>()
                ;
        }
    }
}
