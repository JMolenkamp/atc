﻿using System.CodeDom.Compiler;

//------------------------------------------------------------------------------
// This code was auto-generated by ApiGenerator 1.0.155.0.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
//
// ReSharper disable once CheckNamespace
namespace Demo.Api.Generated.Contracts
{
    /// <summary>
    /// Address.
    /// </summary>
    [GeneratedCode("ApiGenerator", "1.0.155.0")]
    public class Address
    {
        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string PostalCode { get; set; }

        public string CityName { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        public Country MyCountry { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(StreetNumber)}: {StreetNumber}, {nameof(PostalCode)}: {PostalCode}, {nameof(CityName)}: {CityName}, {nameof(MyCountry)}: ({MyCountry})";
        }
    }
}