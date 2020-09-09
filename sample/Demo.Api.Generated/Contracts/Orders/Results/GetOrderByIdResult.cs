﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Orders
{
    /// <summary>
    /// Results for operation request.
    /// Description: Get order by id.
    /// Operation: GetOrderById.
    /// Area: Orders.
    /// </summary>
    [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Should not throw ArgumentNullExceptions from implicit operators.")]
    public class GetOrderByIdResult
    {
        private readonly ActionResult result;

        private GetOrderByIdResult(ActionResult result)
        {
            this.result = result ?? throw new ArgumentNullException(nameof(result));
        }

        /// <summary>
        /// 200 - Ok response.
        /// </summary>
        public static GetOrderByIdResult Ok(Order response) => new GetOrderByIdResult(new OkObjectResult(response));

        /// <summary>
        /// 404 - NotFound response.
        /// </summary>
        public static GetOrderByIdResult NotFound(string? message = null) => new GetOrderByIdResult(ResultFactory.CreateContentResultWithProblemDetails(HttpStatusCode.NotFound, message));

        /// <summary>
        /// Performs an implicit conversion from GetOrderByIdResult to ActionResult.
        /// </summary>
        public static implicit operator ActionResult(GetOrderByIdResult x) => x.result;

        /// <summary>
        /// Performs an implicit conversion from GetOrderByIdResult to ActionResult.
        /// </summary>
        public static implicit operator GetOrderByIdResult(Order x) => Ok(x);
    }
}