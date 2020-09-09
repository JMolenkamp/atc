﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Endpoints
{
    /// <summary>
    /// Endpoint definitions.
    /// Area: Users.
    /// </summary>
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Description: Get all users.
        /// Operation: GetUsers.
        /// Area: Users.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> GetUsersAsync([FromServices] IGetUsersHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(cancellationToken);
        }

        /// <summary>
        /// Description: Create a new user.
        /// Operation: PostUsers.
        /// Area: Users.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> PostUsersAsync(PostUsersParameters parameters, [FromServices] IPostUsersHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        /// <summary>
        /// Description: Get user by id.
        /// Operation: GetUserById.
        /// Area: Users.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> GetUserByIdAsync(GetUserByIdParameters parameters, [FromServices] IGetUserByIdHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        /// <summary>
        /// Description: Update user by id.
        /// Operation: UpdateUserById.
        /// Area: Users.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateUserByIdAsync(UpdateUserByIdParameters parameters, [FromServices] IUpdateUserByIdHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        /// <summary>
        /// Description: Delete user by id.
        /// Operation: DeleteUserById.
        /// Area: Users.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> DeleteUserByIdAsync(DeleteUserByIdParameters parameters, [FromServices] IDeleteUserByIdHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        /// <summary>
        /// Description: Update gender on a user.
        /// Operation: UpdateMyTestGender.
        /// Area: Users.
        /// </summary>
        [HttpPut("{id}/gender")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> UpdateMyTestGenderAsync(UpdateMyTestGenderParameters parameters, [FromServices] IUpdateMyTestGenderHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }

        /// <summary>
        /// Description: Get user by email.
        /// Operation: GetUserByEmail.
        /// Area: Users.
        /// </summary>
        [HttpGet("email")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<ActionResult> GetUserByEmailAsync(GetUserByEmailParameters parameters, [FromServices] IGetUserByEmailHandler handler, CancellationToken cancellationToken)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return await handler.ExecuteAsync(parameters, cancellationToken);
        }
    }
}