﻿using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    public static class OpenApiParameterExtensions
    {
        public static bool HasFormatTypeOfUuid(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Uuid, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfDate(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Date, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfTime(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Time, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfTimestamp(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Timestamp, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfDateTime(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.DateTime, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfEmail(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Email, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfUri(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Uri, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeOfByte(this IList<OpenApiParameter> parameters)
        {
            return parameters.Any(x => !string.IsNullOrEmpty(x.Schema.Format) && x.Schema.Format.Equals(OpenApiFormatTypeConstants.Byte, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiParameter> parameters)
        {
            return parameters.HasFormatTypeOfByte() ||
                   parameters.HasFormatTypeOfDate() ||
                   parameters.HasFormatTypeOfTime() ||
                   parameters.HasFormatTypeOfTimestamp() ||
                   parameters.HasFormatTypeOfDateTime() ||
                   parameters.HasFormatTypeOfUuid();
        }

        public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiParameter> parameters)
        {
            return parameters.HasFormatTypeOfEmail() ||
                   parameters.HasFormatTypeOfUri();
        }

        public static List<OpenApiParameter> GetAllFromRoute(this IList<OpenApiParameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return parameters.Where(x => x.In == ParameterLocation.Path).ToList();
        }

        public static List<OpenApiParameter> GetAllFromHeader(this IList<OpenApiParameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return parameters.Where(x => x.In == ParameterLocation.Header).ToList();
        }

        public static List<OpenApiParameter> GetAllFromQuery(this IList<OpenApiParameter> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            return parameters.Where(x => x.In == ParameterLocation.Query).ToList();
        }
    }
}