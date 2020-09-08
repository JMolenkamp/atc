﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts.Users;

namespace Demo.Domain.Handlers.Users
{
    public class UpdateMyTestGenderHandler : IUpdateMyTestGenderHandler
    {
        public async Task<UpdateMyTestGenderResult> ExecuteAsync(UpdateMyTestGenderParameters parameters, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return await Task.FromResult("We are now updated.");
        }
    }
}