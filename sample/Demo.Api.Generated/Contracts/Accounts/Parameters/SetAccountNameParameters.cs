﻿using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.155.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Accounts
{
    /// <summary>
    /// Parameters for operation request.
    /// Description: Set name of account.
    /// Operation: SetAccountName.
    /// Area: Accounts.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.155.0")]
    public class SetAccountNameParameters
    {
        /// <summary>
        /// The accountId.
        /// </summary>
        [FromRoute(Name = "accountId")]
        [Required]
        public string AccountId { get; set; }
    }
}