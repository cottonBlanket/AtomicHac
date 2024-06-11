namespace AtomicHac.Logic.Constants;

internal static class VectorizerApi
{
    private const string Root = "http://localhost:5000";
    private const string AddDocumentApiResource = "/api/add_document";
    private const string SearchApiResource = "/api/search";


    internal static string GetDocumentApiUrl()
    {
        return $"{Root}{AddDocumentApiResource}";
    }
    
    internal static string GetSearchApiUrl()
    {
        return $"{Root}{SearchApiResource}";
    }
}