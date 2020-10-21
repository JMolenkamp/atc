﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Atc.CodeAnalysis.CSharp.Factories
{
    /// <summary>
    /// SuppressMessage Attribute Factory.
    /// </summary>
    /// <remarks>
    /// Code Analysis Warnings for Managed Code by CheckId:
    /// https://docs.microsoft.com/en-us/visualstudio/code-quality/code-analysis-warnings-for-managed-code-by-checkid?view=vs-2019.
    /// </remarks>
    public static class SuppressMessageAttributeFactory
    {
        [SuppressMessage("Info Code Smell", "S1135:Track uses of \"TODO\" tags", Justification = "Allow TODO here.")]
        public static SuppressMessageAttribute Create(int checkId, string? justification)
        {
            if (string.IsNullOrEmpty(justification))
            {
                justification = "OK.";
            }

            return checkId switch
            {
                // TODO: Add all rules
                1062 => new SuppressMessageAttribute("Design", "CA1062:Validate arguments of public methods") { Justification = justification },
                1720 => new SuppressMessageAttribute("Naming", "CA1720:Identifiers should not contain type names") { Justification = justification },
                _ => throw new NotImplementedException($"Rule for CA{checkId} must be implemented.")
            };
        }
    }
}