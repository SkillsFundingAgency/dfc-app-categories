﻿using DFC.App.JobCategories.Data.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.JobCategories.UnitTests.ControllerTests.SitemapControllerTests
{
    [Trait("Category", "Sitemap Controller Unit Tests")]
    public class SitemapControllerSitemapTests : BaseSitemapController
    {
        [Fact]
        public async Task SitemapControllerSitemapReturnsSuccess()
        {
            // Arrange
            const int resultsCount = 3;
            var expectedResults = A.CollectionOfFake<JobCategory>(resultsCount);
            var controller = BuildSitemapController();

            expectedResults[0].CanonicalName = "default-article";
            expectedResults[1].CanonicalName = "yes-in-sitemap";
            expectedResults[2].CanonicalName = "in-sitemap";

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).Returns(expectedResults);

            // Act
            var result = await controller.Sitemap().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();

            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Application.Xml);

            controller.Dispose();
        }

        [Fact]
        public async Task SitemapControllerSitemapReturnsSuccessWhenNoData()
        {
            // Arrange
            const int resultsCount = 0;
            var expectedResults = A.CollectionOfFake<JobCategory>(resultsCount);
            var controller = BuildSitemapController();

            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).Returns(expectedResults);

            // Act
            var result = await controller.Sitemap().ConfigureAwait(false);

            // Assert
            A.CallTo(() => FakeDocumentService.GetAllAsync(null)).MustHaveHappenedOnceExactly();

            var contentResult = Assert.IsType<ContentResult>(result);

            contentResult.ContentType.Should().Be(MediaTypeNames.Application.Xml);

            controller.Dispose();
        }
    }
}
