namespace Atc.Rest.Extensions;

public static class EndpointRouteBuilderExExtensions
{
    private static readonly Dictionary<string, string> YamlCache = new(StringComparer.Ordinal);

    [SuppressMessage("Performance", "CA1849:Call async methods when in an async method", Justification = "OK. The async method is a sub-method.")]
    public static void MapApiSpecificationEndpoint(
        this IEndpointRouteBuilder endpoints,
        List<AssemblyPairOptions> assemblyPairs)
    {
        ArgumentNullException.ThrowIfNull(assemblyPairs);

        var yamlEndpoints = new List<string>();
        foreach (var assemblyPair in assemblyPairs)
        {
            var apiAssemblyName = assemblyPair.ApiAssembly.GetName().Name!;
            var resourceStream = assemblyPair.ApiAssembly.GetManifestResourceStream($"{apiAssemblyName}.Resources.ApiSpecification.yaml");
            if (resourceStream is null)
            {
                continue;
            }

            var yamlEndpoint = $"{apiAssemblyName}.ApiSpecification.yaml";
            endpoints.Map(yamlEndpoint, async context =>
            {
                string yaml;
                if (YamlCache.TryGetValue(yamlEndpoint, out var value))
                {
                    yaml = value;
                }
                else
                {
                    Stream? stream = null;
                    try
                    {
                        stream = resourceStream;
                        using var reader = new StreamReader(stream);
                        yaml = await reader.ReadToEndAsync();
                        YamlCache.Add(yamlEndpoint, yaml);
                    }
                    finally
                    {
                        // ReSharper disable once MethodHasAsyncOverload
                        stream?.Dispose();
                    }
                }

                context.Response.ContentType = "application/x-yaml";
                await context.Response.WriteAsync(yaml);
            });

            yamlEndpoints.Add(yamlEndpoint);
        }

        if (yamlEndpoints.Count > 0)
        {
            endpoints
                .MapGet("/ApiSpecifications", async context =>
                {
                    var links = yamlEndpoints
                        .Select(yamlEndpoint => $"{context.Request.Scheme}://{context.Request.Host}/{yamlEndpoint}")
                        .ToList();
                    var response = JsonSerializer.Serialize(links);
                    await context.Response.WriteAsync(response);
                })
                .WithMetadata(new AllowAnonymousAttribute())
                .WithGroupName("API-Management");
        }
    }

    public static void MapApiManagementAssemblyInformations(
        this IEndpointRouteBuilder endpoints)
        => endpoints.MapApiAssemblyInformations("/management/assembly-informations");

    public static void MapApiAssemblyInformations(
        this IEndpointRouteBuilder endpoints,
        string pattern)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        if (string.IsNullOrEmpty(pattern))
        {
            pattern = "/assembly-informations";
        }

        endpoints
            .MapGet(pattern, async context =>
            {
                var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(
                    new JsonSerializerFactorySettings
                    {
                        UseConverterVersion = true,
                    });

                var assemblyInformations = AppDomain.CurrentDomain.GetAssemblyInformations();
                var response = JsonSerializer.Serialize(assemblyInformations, jsonSerializerOptions);
                await context.Response.WriteAsync(response);
            })
            .WithMetadata(new AllowAnonymousAttribute())
            .WithGroupName("API-Management");
    }
}