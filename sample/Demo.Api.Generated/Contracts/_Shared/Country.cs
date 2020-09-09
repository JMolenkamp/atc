﻿using System.ComponentModel.DataAnnotations;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.0.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts
{
    /// <summary>
    /// Country.
    /// </summary>
    public class Country
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Alpha2Code { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Alpha2Code)}: {Alpha2Code}, {nameof(Alpha3Code)}: {Alpha3Code}";
        }
    }
}