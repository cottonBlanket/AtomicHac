using System.Net.Http.Json;
using AtomicHac.Dal.Document.Model;
using AtomicHac.Logic.Constants;
using AtomicHac.Logic.Query.Interfaces;

namespace AtomicHac.Logic.Query;

public class QueryManager(HttpClient httpClient) : IQueryManager
{
    public async Task<HttpResponseMessage> GetResponseByQuery(string queryRequest)
    {
        var vectorizerResponse =
            await httpClient.PostAsJsonAsync(VectorizerApi.GetSearchApiUrl(), new { query = queryRequest });
        vectorizerResponse.EnsureSuccessStatusCode();
        var documents = await vectorizerResponse.Content.ReadFromJsonAsync<List<DocumentDal>>();
        var content = string.Join(" ", documents.Select(d => d.Content));

        var response = await httpClient.PostAsJsonAsync(LlmApi.GetResponseApiUrl(),
            new { context = content, query = queryRequest });
        return response;
    }
}