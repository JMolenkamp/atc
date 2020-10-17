﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Users;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//--
namespace Demo.Api.Tests.Endpoints.Users.Generated
{
    [GeneratedCode("ApiGenerator", "1.0.0.0")]
    public class UpdateMyTestGenderTests : WebApiControllerBaseTest
    {
        public UpdateMyTestGenderTests(WebApiStartupFactory fixture) : base(fixture) { }

        [Theory]
        [InlineData("/api/v1/users/27/gender")]
        public async Task UpdateMyTestGender_Ok(string relativeRef)
        {
            // Arrange
            var data = new UpdateTestGenderRequest
            {
                Gender = GenderType.Female,
            };

            // Act
            var response = await HttpClient.PutAsync(relativeRef, ToJson(data));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}