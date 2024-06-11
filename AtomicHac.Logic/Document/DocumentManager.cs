using System.Net.Http.Json;
using AtomicHac.Dal.Document.Model;
using AtomicHac.Logic.Constants;
using AtomicHac.Logic.Document.Interfaces;

namespace AtomicHac.Logic.Document;

public class DocumentManager(HttpClient httpClient): IDocumentManager
{
    public async Task AddDocumentAsync(DocumentDal doc)
    {
        var response = await httpClient.PostAsJsonAsync(VectorizerApi.GetDocumentApiUrl(), doc);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<DocumentDal>> SearchAsync(string query)
    {
        var response = await httpClient.PostAsJsonAsync(VectorizerApi.GetSearchApiUrl(), new { query });
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<DocumentDal>>();
    }
    
    public async Task<HttpResponseMessage> PostAsync(string url, object data)
    {
        var response = await httpClient.PostAsJsonAsync(url, data);
        return response;
    }
}
