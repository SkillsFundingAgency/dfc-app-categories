﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DFC.App.JobCategories.IntegrationTests.ControllerTests.HomeControllerTests
{
    [Trait("Category", "Integration")]
    public class HomeControllerRouteTests : IClassFixture<CustomWebApplicationFactory<DFC.App.JobCategories.Startup>>
    {
        private readonly CustomWebApplicationFactory<DFC.App.JobCategories.Startup> factory;

        public HomeControllerRouteTests(CustomWebApplicationFactory<DFC.App.JobCategories.Startup> factory)
        {
            this.factory = factory;

            DataSeeding.SeedDefaultArticles(factory);
        }

        public static IEnumerable<object[]> HomeContentRouteData => new List<object[]>
        {
            new object[] { "/Home/Error" },
        };

        [Theory]
        [MemberData(nameof(HomeContentRouteData))]
        public async Task GetHomeHtmlContentEndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var uri = new Uri(url, UriKind.Relative);
            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Act
            var response = await client.GetAsync(uri).ConfigureAwait(false);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal($"{MediaTypeNames.Text.Html}; charset={Encoding.UTF8.WebName}", response.Content.Headers.ContentType.ToString());
        }
    }
}