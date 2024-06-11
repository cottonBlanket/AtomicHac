namespace AtomicHac.Dal.Document.Model;

public class DocumentDal
{
    public string Id { get; set; }
    public string Content { get; set; }
    public float[] Vector { get; set; }
}