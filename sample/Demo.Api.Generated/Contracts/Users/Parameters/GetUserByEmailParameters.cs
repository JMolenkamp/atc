﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts.Users
{
    /// <summary>
    /// Parameters for operation request.
    /// Description: Get user by email.
    /// Operation: GetUserByEmail.
    /// Area: Users.
    /// </summary>
    public class GetUserByEmailParameters
    {
        /// <summary>
        /// The email of the user to retrieve.
        /// </summary>
        [FromQuery(Name = "email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Email)}: {Email}";
        }
    }
}