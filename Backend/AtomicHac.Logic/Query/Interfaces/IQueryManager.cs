namespace AtomicHac.Logic.Query.Interfaces;

public interface IQueryManager
{
    Task<HttpResponseMessage> GetResponseByQuery(string queryRequest);
}