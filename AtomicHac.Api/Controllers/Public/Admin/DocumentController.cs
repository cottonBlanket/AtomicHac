using AtomicHac.Dal.Document.Model;
using AtomicHac.Logic.Document.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtomicHac.Api.Controllers.Public.Admin;

[ApiController]
[Route("api/[controller]")]
public class AdminController(IDocumentManager documentManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddDocument([FromBody] DocumentDal doc)
    {
        await documentManager.AddDocumentAsync(doc);
        return Ok();
    }
}