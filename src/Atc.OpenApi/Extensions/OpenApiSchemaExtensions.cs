using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable InvertIf
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UseDeconstruction
// ReSharper disable UseDeconstructionOnParameter
// ReSharper disable once CheckNamespace
namespace Microsoft.OpenApi.Models
{
    //// https://swagger.io/docs/specification/data-models/
    //// https://swagger.io/docs/specification/data-models/data-types/-> "String Formats"

    public static class OpenApiSchemaExtensions
    {
        public static bool HasDataTypeList(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsTypeArray());
        }

        public static bool HasFormatTypeUuid(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeUuid());
        }

        public static bool HasFormatTypeDate(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeDate());
        }

        public static bool HasFormatTypeTime(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeTime());
        }

        public static bool HasFormatTypeTimestamp(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeTimestamp());
        }

        public static bool HasFormatTypeDateTime(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeDateTime());
        }

        public static bool HasFormatTypeByte(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeByte());
        }

        public static bool HasFormatTypeInt32(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeInt32());
        }

        public static bool HasFormatTypeInt64(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeInt64());
        }

        public static bool HasFormatTypeEmail(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeEmail());
        }

        public static bool HasFormatTypeUri(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.IsFormatTypeUri());
        }

        public static bool HasFormatTypeFromSystemNamespace(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsFormatTypeUuid() ||
                   schema.IsFormatTypeDate() ||
                   schema.IsFormatTypeDateTime() ||
                   schema.IsFormatTypeTime() ||
                   schema.IsFormatTypeTimestamp() ||
                   schema.IsFormatTypeUri();
        }

        public static bool HasFormatTypeFromSystemNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasFormatTypeFromSystemNamespace());
        }

        public static bool HasDataTypeFromSystemCollectionGenericNamespace(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsTypeArray();
        }

        public static bool HasDataTypeFromSystemCollectionGenericNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasDataTypeFromSystemCollectionGenericNamespace());
        }

        public static bool HasFormatTypeFromDataAnnotationsNamespace(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsFormatTypeEmail() ||
                   schema.IsFormatTypeUri() ||
                   schema.IsRuleValidationString() ||
                   schema.IsRuleValidationNumber();
        }

        public static bool HasFormatTypeFromDataAnnotationsNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasFormatTypeFromDataAnnotationsNamespace());
        }

        public static bool HasFormatType(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return !string.IsNullOrEmpty(schema.Format);
        }

        public static bool HasItemsWithSimpleDataType(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Items != null && schema.Items.IsSimpleDataType();
        }

        public static bool HasItemsWithFormatTypeBinary(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Items != null && schema.Items.IsFormatTypeBinary();
        }

        public static bool HasAnyProperties(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.OneOf != null &&
                schema.OneOf.Count == 1 &&
                schema.OneOf.First().Properties.Count > 0)
            {
                return true;
            }

            return schema.Properties.Count > 0;
        }

        public static bool HasAnyPropertiesWithFormatTypeBinary(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (!schema.HasAnyProperties())
            {
                return false;
            }

            foreach (var schemaProperty in schema.Properties)
            {
                if (schemaProperty.Value.IsFormatTypeBinary())
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasAnyPropertiesAsArrayWithFormatTypeBinary(this OpenApiSchema schema)
        {
            if (schema.Items is null && schema.HasAnyProperties())
            {
                foreach (var (_, value) in schema.Properties)
                {
                    if (value.Type != OpenApiDataTypeConstants.Array)
                    {
                        continue;
                    }

                    if (value.HasItemsWithFormatTypeBinary())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool HasAnythingAsFormatTypeBinary(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return
                schema.IsFormatTypeBinary() ||
                schema.HasItemsWithFormatTypeBinary() ||
                schema.HasAnyPropertiesWithFormatTypeBinary() ||
                schema.HasAnyPropertiesAsArrayWithFormatTypeBinary();
        }

        public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema)
        {
            return schema.HasAnyProperties() &&
                   schema.Properties.Any(x => x.Value.HasFormatTypeFromSystemNamespace());
        }

        public static bool HasAnyPropertiesFormatTypeFromSystemNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
        {
            if (!schema.HasAnyProperties())
            {
                return false;
            }

            foreach (var schemaProperty in schema.Properties)
            {
                if (schemaProperty.Value.HasFormatTypeFromSystemNamespace())
                {
                    return true;
                }

                if (!schemaProperty.Value.IsObjectReferenceTypeDeclared())
                {
                    continue;
                }

                var childModelName = schemaProperty.Value.GetModelName();
                if (string.IsNullOrEmpty(childModelName))
                {
                    continue;
                }

                var childSchema = componentSchemas.FirstOrDefault(x => x.Key == childModelName);
                if (string.IsNullOrEmpty(childSchema.Key))
                {
                    continue;
                }

                if (childSchema.Value.HasAnyPropertiesFormatTypeFromSystemNamespace(componentSchemas))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasAnyPropertiesFormatFromSystemCollectionGenericNamespace(this OpenApiSchema schema, IDictionary<string, OpenApiSchema> componentSchemas)
        {
            if (!schema.HasAnyProperties())
            {
                return false;
            }

            foreach (var schemaProperty in schema.Properties)
            {
                if (schemaProperty.Value.HasDataTypeFromSystemCollectionGenericNamespace())
                {
                    return true;
                }

                if (!schemaProperty.Value.IsObjectReferenceTypeDeclared())
                {
                    continue;
                }

                var childModelName = schemaProperty.Value.GetModelName();
                if (string.IsNullOrEmpty(childModelName))
                {
                    continue;
                }

                var childSchema = componentSchemas.FirstOrDefault(x => x.Key == childModelName);
                if (string.IsNullOrEmpty(childSchema.Key))
                {
                    continue;
                }

                if (childSchema.Value.HasAnyPropertiesFormatFromSystemCollectionGenericNamespace(componentSchemas))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsFormatTypeBinary() || schema.HasItemsWithFormatTypeBinary();
        }

        public static bool HasFormatTypeFromAspNetCoreHttpNamespace(this IList<OpenApiSchema> schemas)
        {
            if (schemas is null)
            {
                throw new ArgumentNullException(nameof(schemas));
            }

            return schemas.Any(x => x.HasFormatTypeFromAspNetCoreHttpNamespace());
        }

        public static bool IsTypeArray(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return !string.IsNullOrEmpty(schema.Type) && schema.Type.Equals(OpenApiDataTypeConstants.Array, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeUuid(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uuid, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeDate(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Date, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeTime(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Time, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeTimestamp(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Timestamp, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeDateTime(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.DateTime, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeByte(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Byte, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeBinary(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Binary, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeInt32(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int32, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeInt64(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Int64, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeEmail(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Email, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFormatTypeUri(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.HasFormatType() && schema.Format.Equals(OpenApiFormatTypeConstants.Uri, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsRuleValidationString(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.MinLength != null ||
                   schema.MaxLength != null;
        }

        public static bool IsRuleValidationNumber(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Minimum != null ||
                   schema.Maximum != null;
        }

        public static bool IsSimpleDataType(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.Type is null)
            {
                return false;
            }

            var dataType = schema.GetDataType();

            return string.Equals(dataType, OpenApiDataTypeConstants.Boolean, StringComparison.Ordinal) ||
                   string.Equals(dataType, "bool", StringComparison.Ordinal) ||
                   string.Equals(dataType, OpenApiDataTypeConstants.Integer, StringComparison.Ordinal) ||
                   string.Equals(dataType, "int", StringComparison.Ordinal) ||
                   string.Equals(dataType, "long", StringComparison.Ordinal) ||
                   string.Equals(dataType, "double", StringComparison.Ordinal) ||
                   string.Equals(dataType, "float", StringComparison.Ordinal) ||
                   string.Equals(dataType, OpenApiDataTypeConstants.Number, StringComparison.Ordinal) ||
                   string.Equals(dataType, OpenApiDataTypeConstants.String, StringComparison.Ordinal);
        }

        public static bool IsObjectReferenceTypeDeclared(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Reference != null;
        }

        public static bool IsArrayReferenceTypeDeclared(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Type == OpenApiDataTypeConstants.Array &&
                   schema.Items?.Reference != null;
        }

        public static bool IsSchemaEnum(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.Enum != null && schema.Enum.Any();
        }

        public static bool IsSchemaEnumOrPropertyEnum(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            return schema.IsSchemaEnum() ||
                   (schema.Properties.Any(x => x.Value.Enum.Any()) && schema.Properties.Count == 1);
        }

        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static bool IsSharedContract(this OpenApiSchema schema, OpenApiComponents openApiComponents)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (openApiComponents is null)
            {
                throw new ArgumentNullException(nameof(openApiComponents));
            }

            var referencedSchemaSet = new List<Tuple<string, string>>();

            foreach (var itemSchema in openApiComponents.Schemas.Values)
            {
                foreach (var itemPropertySchema in itemSchema.Properties.Values)
                {
                    if (itemPropertySchema.Reference is null)
                    {
                        continue;
                    }

                    var schemaReference = itemPropertySchema.Reference.Id;
                    if (!string.Equals(schema.Title, schemaReference, StringComparison.Ordinal) || itemPropertySchema.IsSchemaEnum())
                    {
                        continue;
                    }

                    if (!referencedSchemaSet.Any(x => string.Equals(x.Item1, itemSchema.Title, StringComparison.Ordinal) && string.Equals(x.Item2, schemaReference, StringComparison.Ordinal)))
                    {
                        referencedSchemaSet.Add(Tuple.Create(itemSchema.Title, schemaReference));
                    }

                    if (referencedSchemaSet.Any(x => !string.Equals(x.Item1, itemSchema.Title, StringComparison.Ordinal) && string.Equals(x.Item2, schemaReference, StringComparison.Ordinal)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string GetModelName(this OpenApiSchema schema, bool ensureFirstCharacterToUpper = true)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.AllOf.Count == 2 &&
                (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                 NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase)))
            {
                if (!NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[0].GetModelName();
                }

                if (!NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[1].GetModelName();
                }
            }

            if (schema.Items == null && schema.Reference is null)
            {
                return string.Empty;
            }

            if (schema.Items != null &&
                !OpenApiDataTypeConstants.Object.Equals(schema.Items.Type, StringComparison.Ordinal))
            {
                return string.Empty;
            }

            if (ensureFirstCharacterToUpper)
            {
                return schema.Items == null
                    ? schema.Reference.Id.EnsureFirstCharacterToUpper()
                    : schema.Items.Reference.Id.EnsureFirstCharacterToUpper();
            }

            return schema.Items == null
                ? schema.Reference.Id
                : schema.Items.Reference.Id;
        }

        public static string? GetModelType(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.AllOf.Count == 2 &&
                (NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase) ||
                 NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase)))
            {
                if (!NameConstants.Pagination.Equals(schema.AllOf[0].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[0].GetModelType();
                }

                if (!NameConstants.Pagination.Equals(schema.AllOf[1].Reference?.Id, StringComparison.OrdinalIgnoreCase))
                {
                    return schema.AllOf[1].GetModelType();
                }
            }

            return schema.Type;
        }

        public static string GetDataType(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            var dataType = schema.Type;

            switch (schema.Type)
            {
                case OpenApiDataTypeConstants.Number:
                    return "double";
                case OpenApiDataTypeConstants.Integer:
                    return string.Equals(schema.Format, OpenApiFormatTypeConstants.Int64, StringComparison.Ordinal)
                        ? "long"
                        : "int";
                case OpenApiDataTypeConstants.Boolean:
                    return "bool";
                case OpenApiDataTypeConstants.Array:
                    return "Array";
            }

            if (!string.IsNullOrEmpty(schema.Format))
            {
                switch (schema.Format)
                {
                    case OpenApiFormatTypeConstants.Uuid:
                        return "Guid";
                    case OpenApiFormatTypeConstants.Date:
                    case OpenApiFormatTypeConstants.Time:
                    case OpenApiFormatTypeConstants.Timestamp:
                    case OpenApiFormatTypeConstants.DateTime:
                        return "DateTimeOffset";
                    case OpenApiFormatTypeConstants.Byte:
                        return "string";
                    case OpenApiFormatTypeConstants.Binary:
                        return "IFormFile";
                    case OpenApiFormatTypeConstants.Int32:
                        return "int";
                    case OpenApiFormatTypeConstants.Int64:
                        return "long";
                    case OpenApiFormatTypeConstants.Email:
                        return "string";
                    case OpenApiFormatTypeConstants.Uri:
                        return "Uri";
                }
            }

            if (schema.Reference?.Id != null)
            {
                dataType = schema.Reference.Id;
            }
            else if (schema.OneOf != null && schema.OneOf.Count == 1 && schema.OneOf.First().Reference?.Id != null)
            {
                dataType = schema.OneOf.First().Reference.Id;
            }

            return string.Equals(dataType, OpenApiDataTypeConstants.String, StringComparison.Ordinal)
                ? dataType
                : dataType.EnsureFirstCharacterToUpper();
        }

        public static string GetTitleFromPropertyByPropertyKey(this OpenApiSchema schema, string propertyKey)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (propertyKey is null)
            {
                throw new ArgumentNullException(nameof(propertyKey));
            }

            foreach (var property in schema.Properties)
            {
                if (string.Equals(property.Key, propertyKey, StringComparison.Ordinal))
                {
                    return property.Value.Title;
                }
            }

            throw new ItemNotFoundException($"Can't find property title by property-key: {propertyKey}");
        }

        public static Tuple<string, OpenApiSchema> GetEnumSchema(this OpenApiSchema schema)
        {
            if (schema is null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            if (schema.Enum != null && schema.Enum.Any())
            {
                return Tuple.Create(schema.Reference.Id, schema);
            }

            foreach (var schemaProperty in schema.Properties)
            {
                if (!schemaProperty.Value.Enum.Any())
                {
                    continue;
                }

                var enumName = schemaProperty.Value.Reference?.Id ?? schema.Reference.Id;
                return Tuple.Create(enumName, schemaProperty.Value);
            }

            throw new ItemNotFoundException("Schema does not contain an enum!");
        }

        public static OpenApiSchema GetSchemaByModelName(this IDictionary<string, OpenApiSchema> componentSchemas, string modelName)
            => componentSchemas.First(x => x.Key.Equals(modelName, StringComparison.OrdinalIgnoreCase)).Value;

        public static string ExtractPropertyNameWhenHasAnyPropertiesOfArrayWithFormatTypeBinary(this OpenApiSchema apiSchema)
        {
            foreach (var (key, value) in apiSchema.Properties)
            {
                if (value.Type == OpenApiDataTypeConstants.Array)
                {
                    return key.EnsureFirstCharacterToUpper();
                }
            }

            return string.Empty;
        }
    }
}