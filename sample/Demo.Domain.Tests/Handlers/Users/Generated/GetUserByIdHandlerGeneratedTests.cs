﻿using Demo.Domain.Handlers.Users;
using System;
using System.CodeDom.Compiler;
using Xunit;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//--
// ReSharper disable once CheckNamespace
namespace Demo.Domain.Api.Generated.Handlers.Tests
{
    [GeneratedCode("ApiGenerator", "1.0.0.0")]
    public class GetUserByIdHandlerGeneratedTests
    {
        [Fact]
        public void InstantiateConstructor()
        {
            // Act
            var actual = new GetUserByIdHandler();

            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void ParameterArgumentNullCheck()
        {
            // Arrange
            var sut = new GetUserByIdHandler();

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => sut.ExecuteAsync(null!));
        }
    }
}
