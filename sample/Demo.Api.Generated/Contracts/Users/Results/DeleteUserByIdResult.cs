﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by Atc.Rest.ApiGenerator 1.0.0.0.
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
    /// Description: Delete user by id.
    /// Operation: DeleteUserById.
    /// Area: Users.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    public class DeleteUserByIdResult
    {
        private readonly ActionResult result;

        private DeleteUserByIdResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static DeleteUserByIdResult Ok(string? message = null) => new DeleteUserByIdResult(ResultFactory.CreateContentResult(HttpStatusCode.OK, message));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static DeleteUserByIdResult NotFound(string? message = null) => new DeleteUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// 409 - Conflict response.
        /// </summary>
        public static DeleteUserByIdResult Conflict(string? error = null) => new DeleteUserByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.Conflict, error));

        /// <summary>
        /// Performs an implicit conversion from DeleteUserByIdResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(DeleteUserByIdResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from DeleteUserByIdResult to ActionResult.
        /// </summary>
        public static implicit operator DeleteUserByIdResult(string x) => Ok(x);
    }
}