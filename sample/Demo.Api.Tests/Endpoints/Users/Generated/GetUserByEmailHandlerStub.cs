﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Demo.Api.Generated.Contracts;
using Demo.Api.Generated.Contracts.Users;

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
    public class GetUserByEmailHandlerStub : IGetUserByEmailHandler
    {
        public Task<GetUserByEmailResult> ExecuteAsync(GetUserByEmailParameters parameters, CancellationToken cancellationToken = default)
        {
            var data = new User
            {
                Id = Guid.Parse("77a33260-0000-441f-ba60-b0a833803fab"),
                Gender = GenderType.Female,
                FirstName = "Hallo",
                LastName = "Hallo1",
                Email = "john.doe@example.com",
                HomeAddress = new Address(),
                CompanyAddress = new Address(),
            };

            return Task.FromResult(GetUserByEmailResult.Ok(data));
        }
    }
}
