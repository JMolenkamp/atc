﻿using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.155.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Results for operation request.
    /// Description: Create a new user.
    /// Operation: PostUser.
    /// Area: Users.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    [GeneratedCode("ApiGenerator", "1.0.155.0")]
    public class PostUserResult
    {
        private readonly ActionResult result;

        private PostUserResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 201 - Created response.
        /// </summary>
        public static PostUserResult Created() => new PostUserResult(ResultFactory.CreateContentResult(HttpStatusCode.Created, null));

        /// <summary>
        /// 400 - BadRequest response.
        /// </summary>
        public static PostUserResult BadRequest(string message) => new PostUserResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.BadRequest, message));

        /// <summary>
        /// 409 - Conflict response.
        /// </summary>
        public static PostUserResult Conflict(string? error = null) => new PostUserResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.Conflict, error));

        /// <summary>
        /// Performs an implicit conversion from PostUserResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(PostUserResult x) => x.result;
    }
}