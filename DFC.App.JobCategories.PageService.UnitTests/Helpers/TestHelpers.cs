﻿using DFC.App.JobCategories.Data.Extensions;
using DFC.App.JobCategories.Data.Models;
using DFC.App.JobCategories.Data.Models.API;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DFC.App.JobCategories.PageService.UnitTests.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class TestHelpers
    {

        public static OccupationLabelApiResponse GetOccupationLabelApiResponse()
        {
            return new OccupationLabelApiResponse
            {
                Title = "An occupation label",
                Uri = new Uri("http://somehost/someresource/occupationlabel/a4415817-0ca4-487e-af74-2e8276c606d9")
            };
        }

        public static OccupationApiResponse GetOccupationApiResponse()
        {
            return new OccupationApiResponse
            {
                Title = "Test Occupation",
                Uri = new Uri("http://somehost/someresource/occupation/54288fad-2f99-43cb-8df0-d10d29977a4b"),
                Links = new List<Link>
                {
                    new Link { LinkValue = new KeyValuePair<string, DynamicLink>("occupationlabel", new DynamicLink() { Href = new Uri("http://somehost/someresource/occupationlabel/a4415817-0ca4-487e-af74-2e8276c606d9"), Relationship="ncs__hasAltLabel" }) },
                    new Link { LinkValue = new KeyValuePair<string, DynamicLink>("occupationlabel", new DynamicLink() { Href = new Uri("http://somehost/someresource/occupationlabel/a4415817-0ca4-487e-af74-2e8276c606d9"), Relationship="ncs__hasAltLabel" }) },
                },
            };
        }

        public static JobCategoryApiResponse GetJobCategoryApiResponse()
        {
            return new JobCategoryApiResponse
            {
                Description = "A Test Job Category",
                Title = "Test Job Category",
                WebsiteUri = new Uri("http://somehost/someresource/occupation/18419c07-400b-4de1-a893-36d419b18ec7/"),
                Uri = new Uri("http://somehost/someresource/occupation/18419c07-400b-4de1-a893-36d419b18ec7/"),
                Links = new List<Link>
                {
                    new Link { LinkValue = new KeyValuePair<string, DynamicLink>("jobprofile", new DynamicLink() { Href = new Uri($"http://somehost/someresource/jobprofile/46a884da-22bb-4ebe-87ac-228f42698ee2/") }) },
                    new Link { LinkValue = new KeyValuePair<string, DynamicLink>("jobprofile", new DynamicLink() { Href = new Uri($"http://somehost/someresource/jobprofile/{Guid.NewGuid()}/") }) },
                },
            };
        }

        public static JobProfileApiResponse GetJobProfileApiResponse()
        {
            return new JobProfileApiResponse
            {
                Description = "A Test Job Profile",
                Title = "Test Job Profile",
                Uri = new Uri($"http://somehost/someresource/jobprofile/46a884da-22bb-4ebe-87ac-228f42698ee2"),
                Links = new List<Link>
                {
                    new Link { LinkValue = new KeyValuePair<string, DynamicLink>("occupation", new DynamicLink() { Href = new Uri("http://somehost/someresource/occupation/54288fad-2f99-43cb-8df0-d10d29977a4b") }) },
                },
            };
        }

        public static JobProfile GetJobProfile()
        {
            var jp = GetJobProfileApiResponse().Map();
            var occupation = GetOccupationApiResponse();

            jp.Occupation = new Occupation(occupation.Title, occupation.Uri, new List<OccupationLabel>());

            return jp;
        }

        public static JobCategory GetJobCategory()
        {
            return GetJobCategoryApiResponse().Map();
        }
    }
}