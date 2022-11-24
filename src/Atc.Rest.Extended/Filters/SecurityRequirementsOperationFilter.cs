namespace Atc.Rest.Extended.Filters;

public class SecurityRequirementsOperationFilter : IOperationFilter
{
    public void Apply(
        OpenApiOperation operation,
        OperationFilterContext context)
    {
        ArgumentNullException.ThrowIfNull(operation);
        ArgumentNullException.ThrowIfNull(context);

        if (context.GetControllerAndActionAttributes<AllowAnonymousAttribute>().Any())
        {
            return;
        }

        var authorizeAttributes = context.GetControllerAndActionAttributes<AuthorizeAttribute>().ToList();
        if (!authorizeAttributes.Any())
        {
            return;
        }

        // Policy names map to scopes
        var requiredScopes = authorizeAttributes
            .Select(attr => attr.Policy)
            .Distinct(StringComparer.Ordinal)
            .ToList();

        if (!requiredScopes.Any())
        {
            return;
        }

        operation.Responses["401"] = new OpenApiResponse { Description = "Unauthorized - Request was valid but the calling user does not have the required role" };
        operation.Responses["403"] = new OpenApiResponse { Description = "Forbidden - The request was valid, but the server is refusing action. The user might not have the necessary permissions for a resource" };

        var oAuthScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = nameof(SecuritySchemeType.OAuth2),
            },
        };

        operation.Security = new List<OpenApiSecurityRequirement>
        {
            new()
            {
                [oAuthScheme] = requiredScopes,
            },
        };
    }
}