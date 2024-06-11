using AtomicHac.Api.Controllers.Public.Query.Dto.Request;
using AtomicHac.Api.Controllers.Public.Query.Dto.Response;
using AtomicHac.Logic.Query.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtomicHac.Api.Controllers.Public.Query;

[ApiController]
[Route("api/[controller]")]
public class QueryController(IQueryManager queryManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetQueryResponse([FromBody] QueryRequest queryRequest)
    {
        var response = await queryManager.GetResponseByQuery(queryRequest.Query);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode);
        }
        
        var result = await response.Content.ReadFromJsonAsync<QueryResponse>();
        return Ok(result);

    }
}