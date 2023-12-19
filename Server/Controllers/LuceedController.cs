using LuceedDemo.Server.Config;
using LuceedDemo.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LuceedDemo.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LuceedController : ControllerBase
{
    private readonly LuceedApiClient _client;

    public LuceedController(LuceedApiClient client)
    {
        _client = client;
    }

    [HttpGet("articles/{name}")]
    public async Task<IActionResult> Get(string name)
    {
        var response = await _client.GetArticlesByNameAsync(name);

        //var str = await response.Content.ReadAsStringAsync();

        var result = await response.Content.ReadFromJsonAsync<ArticlesResult>();

        return Ok(result.result[0].artikli);
    }
}
