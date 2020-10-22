﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Accounts;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.155.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//--
namespace Demo.Api.Tests.Endpoints.Accounts.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.155.0")]
    public class SetAccountNameTests : WebApiControllerBaseTest
    {
        public SetAccountNameTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/accounts/27/name")]
        public async Task SetAccountName_Ok(string relativeRef)
        {
            // Act
            var response = await HttpClient.PostAsync(relativeRef, ToJson(new {}));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}