// ReSharper disable once CheckNamespace
namespace System.Net;

public static class HttpStatusCodeExtensions
{
    public static string ToNormalizedString(
        this HttpStatusCode httpStatusCode)
        => httpStatusCode switch
        {
            HttpStatusCode.OK => "Ok",
            HttpStatusCode.IMUsed => "ImUsed",
            _ => httpStatusCode.ToString(),
        };

    public static string ToStatusCodesConstant(
        this HttpStatusCode httpStatusCode)
        => httpStatusCode switch
        {
            HttpStatusCode.NonAuthoritativeInformation => "Status203NonAuthoritative",
            HttpStatusCode.Unused => "Status306SwitchProxy",
            HttpStatusCode.RedirectKeepVerb => "Status307TemporaryRedirect",
            HttpStatusCode.HttpVersionNotSupported => "Status505HttpVersionNotsupported",
            _ => $"Status{(int)httpStatusCode}{httpStatusCode}",
        };

    public static bool IsInformational(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 100 && (int)httpStatusCode < 200;

    public static bool IsSuccessful(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 200 && (int)httpStatusCode < 300;

    public static bool IsRedirect(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 300 && (int)httpStatusCode < 400;

    public static bool IsClientError(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 400 && (int)httpStatusCode < 500;

    public static bool IsServerError(this HttpStatusCode httpStatusCode)
        => (int)httpStatusCode >= 500 && (int)httpStatusCode < 600;

    public static bool IsClientOrServerError(this HttpStatusCode httpStatusCode)
        => httpStatusCode.IsClientError() || httpStatusCode.IsServerError();
}