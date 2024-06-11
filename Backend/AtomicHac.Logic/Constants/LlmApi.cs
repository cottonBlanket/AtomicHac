namespace AtomicHac.Logic.Constants;

internal static class LlmApi
{
    private const string Root = "http:/localhost:5001";
    private const string GetResponseApiResource = "/api/get_response";

    internal static string GetResponseApiUrl()
    {
        return $"{Root}{GetResponseApiResource}";
    }
}