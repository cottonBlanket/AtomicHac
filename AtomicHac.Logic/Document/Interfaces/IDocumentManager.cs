using AtomicHac.Dal.Document.Model;

namespace AtomicHac.Logic.Document.Interfaces;

public interface IDocumentManager
{
    Task AddDocumentAsync(DocumentDal doc);
    Task<List<DocumentDal>> SearchAsync(string query);
    Task<HttpResponseMessage> PostAsync(string url, object data);
}