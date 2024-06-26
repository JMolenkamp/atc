<div style='text-align: right'>
[References](Index.md)
</div>

# References extended

## [Atc.Rest](Atc.Rest.md)

- [AtcRestAssemblyTypeInitializer](Atc.Rest.md#atcrestassemblytypeinitializer)
- [IRequestContext](Atc.Rest.md#irequestcontext)
  -  Properties
     - CallingIdentity
     - CorrelationId
     - OnBehalfOfIdentity
     - RequestCancellationToken
     - RequestId
- [RequestContext](Atc.Rest.md#requestcontext)
  -  Properties
     - CallingIdentity
     - CorrelationId
     - OnBehalfOfIdentity
     - RequestCancellationToken
     - RequestId

## [Atc.Rest.Extensions](Atc.Rest.Extensions.md)

- [AllowAnonymousAccessForDevelopmentHandler](Atc.Rest.Extensions.md#allowanonymousaccessfordevelopmenthandler)
  -  Methods
     - HandleAsync(AuthorizationHandlerContext context)
- [EndpointRouteBuilderExExtensions](Atc.Rest.Extensions.md#endpointroutebuilderexextensions)
  -  Static Methods
     - MapApiAssemblyInformations(this IEndpointRouteBuilder endpoints, string pattern)
     - MapApiManagementAssemblyInformations(this IEndpointRouteBuilder endpoints)
     - MapApiSpecificationEndpoint(this IEndpointRouteBuilder endpoints, List&lt;AssemblyPairOptions&gt; assemblyPairs)

## [Atc.Rest.Helpers](Atc.Rest.Helpers.md)

- [ProblemDetailsHelper](Atc.Rest.Helpers.md#problemdetailshelper)
  -  Static Methods
     - IsFormatJsonAndProblemDetailsModel(string value)
     - TrySerializeToProblemDetails(string value, out ProblemDetails problemDetails)
     - TrySerializeToProblemDetailsAndGetDetails(string value, out string detailValue)
     - TrySerializeToProblemDetailsAndGetStatusCode(string value, out HttpStatusCode? statusCodeValue)
     - TrySerializeToProblemDetailsAndGetTitle(string value, out string titleValue)

## [Atc.Rest.Middleware](Atc.Rest.Middleware.md)

- [ExceptionTelemetryMiddleware](Atc.Rest.Middleware.md#exceptiontelemetrymiddleware)
  -  Methods
     - InvokeAsync(HttpContext context)
- [KeepAliveMiddleware](Atc.Rest.Middleware.md#keepalivemiddleware)
  -  Methods
     - InvokeAsync(HttpContext context)
- [RequestCorrelationMiddleware](Atc.Rest.Middleware.md#requestcorrelationmiddleware)
  -  Methods
     - InvokeAsync(HttpContext context)
- [RequestResponseLoggerMiddleware](Atc.Rest.Middleware.md#requestresponseloggermiddleware)
  -  Methods
     - InvokeAsync(HttpContext httpContext)

## [Atc.Rest.Models](Atc.Rest.Models.md)

- [RequestLogModel](Atc.Rest.Models.md#requestlogmodel)
  -  Properties
     - Body
     - ClientIp
     - ContentType
     - DateTimeUtc
     - HeaderParameters
     - Host
     - Method
     - Path
     - QueryParameters
     - QueryString
     - RequestId
     - Scheme
- [RequestResponseLogModel](Atc.Rest.Models.md#requestresponselogmodel)
  -  Properties
     - ExceptionMessage
     - ExceptionStackTrace
     - ExecutionTime
     - Request
     - Response
     - System
  -  Methods
     - SetException(Exception exception)
- [ResponseLogModel](Atc.Rest.Models.md#responselogmodel)
  -  Properties
     - Body
     - ContentType
     - DateTimeUtc
     - HeaderParameters
     - Status

## [Atc.Rest.Options](Atc.Rest.Options.md)

- [AssemblyPairOptions](Atc.Rest.Options.md#assemblypairoptions)
  -  Properties
     - ApiAssembly
     - DomainAssembly
  -  Methods
     - ToString()
- [AuthorizationOptions](Atc.Rest.Options.md#authorizationoptions)
  -  Static Fields
     - string ConfigurationSectionName
  -  Properties
     - Audience
     - ClientId
     - Instance
     - Issuer
     - TenantId
     - ValidAudiences
     - ValidIssuers
  -  Methods
     - IsSecurityEnabled()
- [ConfigureApiBehaviorOptions](Atc.Rest.Options.md#configureapibehavioroptions)
  -  Methods
     - Configure(ApiBehaviorOptions options)
- [RequestResponseLoggerOptions](Atc.Rest.Options.md#requestresponseloggeroptions)
  -  Properties
     - DefaultLogLevel
     - IncludeRequestHeaderParameters
     - IncludeRequestQueryParameters
     - IncludeResponseBody
     - IncludeResponseHeaderParameters
     - SkipSignalrRequests
     - SkipSwaggerRequests
  -  Methods
     - ToString()
- [RestApiOptions](Atc.Rest.Options.md#restapioptions)
  -  Properties
     - AllowAnonymousAccessForDevelopment
     - AssemblyPairs
     - Authorization
     - EnableRequestResponseLogger
     - ErrorHandlingExceptionFilter
     - JsonSerializerCasingStyle
     - RequestResponseLoggerOptions
     - UseApplicationInsights
     - UseAutoRegistrateServices
     - UseEnumAsStringInSerialization
     - UseHttpContextAccessor
     - UseJsonSerializerOptionsIgnoreNullValues
     - UseRequireHttpsPermanent
     - UseValidateServiceRegistrations
  -  Methods
     - AddAssemblyPairs(Assembly apiAssembly, Assembly domainAssembly)
- [RestApiOptionsErrorHandlingExceptionFilter](Atc.Rest.Options.md#restapioptionserrorhandlingexceptionfilter)
  -  Properties
     - Enable
     - IncludeExceptionDetails
     - UseProblemDetailsAsResponseBody

## [Atc.Rest.Results](Atc.Rest.Results.md)

- [Pagination&lt;T&gt;](Atc.Rest.Results.md#pagination&lt;t&gt;)
  -  Properties
     - ContinuationToken
     - Count
     - Items
     - PageIndex
     - PageSize
     - QueryString
     - TotalCount
     - TotalPages
  -  Methods
     - ToString()
- [ResultBase](Atc.Rest.Results.md#resultbase)
- [ResultFactory](Atc.Rest.Results.md#resultfactory)
  -  Static Methods
     - CreateContentResult(HttpStatusCode statusCode, string message, string contentType = application/json)
     - CreateContentResultWithProblemDetails(HttpStatusCode statusCode, object value, string contentType = application/json)
     - CreateContentResultWithProblemDetails(HttpStatusCode statusCode, string message, string contentType = application/json)
     - CreateContentResultWithValidationProblemDetails(HttpStatusCode statusCode, Dictionary&lt;string, string[]&gt; errors, string message, string contentType = application/json)
     - CreateContentResultWithValidationProblemDetails(HttpStatusCode statusCode, string message, string contentType = application/json)
     - CreateFileContentResult(byte[] bytes, string fileName, string contentType = application/octet-stream)
     - CreateProblemDetails(HttpStatusCode statusCode, string message)
     - CreateValidationProblemDetails(HttpStatusCode statusCode, Dictionary&lt;string, string[]&gt; errors, string message)

## [Microsoft.ApplicationInsights.Extensibility](Microsoft.ApplicationInsights.Extensibility.md)

- [Accept4xxResponseAsSuccessInitializer](Microsoft.ApplicationInsights.Extensibility.md#accept4xxresponseassuccessinitializer)
  -  Methods
     - Initialize(ITelemetry telemetry)
- [CallingIdentityTelemetryInitializer](Microsoft.ApplicationInsights.Extensibility.md#callingidentitytelemetryinitializer)
  -  Methods
     - Initialize(ITelemetry telemetry)

## [Microsoft.AspNetCore.Builder](Microsoft.AspNetCore.Builder.md)

- [RestApiBuilderExtensions](Microsoft.AspNetCore.Builder.md#restapibuilderextensions)
  -  Static Methods
     - ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiOptions restApiOptions)
     - ConfigureRestApi(this IApplicationBuilder app, IWebHostEnvironment env, RestApiOptions restApiOptions, Action&lt;IApplicationBuilder&gt; setupAction)
     - UseRestApi(this IApplicationBuilder app, IWebHostEnvironment env)

## [Microsoft.AspNetCore.Http](Microsoft.AspNetCore.Http.md)

- [AnonymousAccessExtensions](Microsoft.AspNetCore.Http.md#anonymousaccessextensions)
  -  Static Methods
     - AddAnonymousAccessForDevelopment(this IServiceCollection services)
- [FormFileExtensions](Microsoft.AspNetCore.Http.md#formfileextensions)
  -  Static Methods
     - GetBytes(this IFormFile formFile)
- [HeaderDictionaryExtensions](Microsoft.AspNetCore.Http.md#headerdictionaryextensions)
  -  Static Methods
     - AddCorrelationId(this IHeaderDictionary headers, string correlationId)
     - GetCallingOnBehalfOfIdentity(this IHeaderDictionary headers)
     - GetOrAddCorrelationId(this IHeaderDictionary headers)
     - GetOrAddRequestId(this IHeaderDictionary headers)
- [HttpContextExExtensions](Microsoft.AspNetCore.Http.md#httpcontextexextensions)
  -  Static Methods
     - GetCorrelationId(this HttpContext context)
     - GetRequestId(this HttpContext context)
- [HttpRequestExExtensions](Microsoft.AspNetCore.Http.md#httprequestexextensions)
  -  Static Methods
     - GetRawBodyBytesAsync(this HttpRequest request)
     - GetRawBodyStringAsync(this HttpRequest request, Encoding encoding = null)
- [WellKnownHttpHeaders](Microsoft.AspNetCore.Http.md#wellknownhttpheaders)
  -  Static Fields
     - string CallingIdentity
     - string Continuation
     - string CorrelationId
     - string ETag
     - string Filename
     - string IfMatch
     - string IfNoneMatch
     - string MaxItemCount
     - string OnBehalfOf
     - string RequestId
     - string ValueSeparator

## [Microsoft.AspNetCore.Mvc.Filters](Microsoft.AspNetCore.Mvc.Filters.md)

- [ErrorHandlingExceptionFilterAttribute](Microsoft.AspNetCore.Mvc.Filters.md#errorhandlingexceptionfilterattribute)
  -  Methods
     - OnException(ExceptionContext context)

## [Microsoft.Extensions.DependencyInjection](Microsoft.Extensions.DependencyInjection.md)

- [ApplicationInsightsExtensions](Microsoft.Extensions.DependencyInjection.md#applicationinsightsextensions)
  -  Static Methods
     - AddCallingIdentityTelemetryInitializer(this IServiceCollection services)
- [RestApiExtensions](Microsoft.Extensions.DependencyInjection.md#restapiextensions)
  -  Static Methods
     - AddRestApi(this IServiceCollection services)
     - AddRestApi(this IServiceCollection services, Action&lt;IMvcBuilder&gt; setupMvcAction, RestApiOptions restApiOptions)
     - AddRestApi(this IServiceCollection services, RestApiOptions restApiOptions)
- [ServiceCollectionExtensions](Microsoft.Extensions.DependencyInjection.md#servicecollectionextensions)
  -  Static Methods
     - AutoRegistrateServices(this IServiceCollection services, Assembly interfaceAssembly, Assembly implementationAssembly)
     - ValidateServiceRegistrations(this IServiceCollection services, Assembly apiAssembly)

## [System](System.md)

- [TypeExtensions](System.md#typeextensions)
  -  Static Methods
     - GetApiName(this Type type, bool removeLastVerb = False)

## [System.Net.Http](System.Net.Http.md)

- [HttpResponseMessageExtensions](System.Net.Http.md#httpresponsemessageextensions)
  -  Static Methods
     - DeserializeAsync(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions jsonSerializerOptions = null)

## [System.Reflection](System.Reflection.md)

- [AssemblyExtensions](System.Reflection.md#assemblyextensions)
  -  Static Methods
     - GetApiName(this Assembly assembly, bool removeLastVerb = False)

<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>
