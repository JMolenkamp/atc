﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

// ReSharper disable ConvertIfStatementToReturnStatement
namespace Demo.Domain.Handlers.Users
{
    [ExcludeFromCodeCoverage]
    public class GetUserByIdHandler : IGetUserByIdHandler
    {
        public Task<GetUserByIdResult> ExecuteAsync(GetUserByIdParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Id == "7")
            {
                return Task.FromResult(GetUserByIdResult.NotFound($"Could not find user with id={parameters.Id}"));
            }

            return InvokeExecuteAsync(parameters, cancellationToken);
        }

        private async Task<GetUserByIdResult> InvokeExecuteAsync(GetUserByIdParameters parameters, CancellationToken cancellationToken)
        {
            var data = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "John.Doe@jd.com"
            };

            return await Task.FromResult(data);
        }
    }
}