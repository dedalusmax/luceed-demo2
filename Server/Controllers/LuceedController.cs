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
    public async Task<IActionResult> GetArticlesByName(string name)
    {
        var response = await _client.GetArticlesByNameAsync(name);

        //var str = await response.Content.ReadAsStringAsync();

        var result = await response.Content.ReadFromJsonAsync<ArticlesResult>();

        return Ok(result?.result[0].artikli);
    }

    [HttpGet("calculation/payment/{type}/{fromdate}")]
    public async Task<IActionResult> GetPaymentCalculationByPaymentType(string type, string fromDate)
    {
        var response = await _client.GetPaymentCalculationByPaymentType(type, fromDate);

        var result = await response.Content.ReadFromJsonAsync<CalculationByPaymentTypeResult>();

        return Ok(result?.result[0].obracun_placanja);
    }

    [HttpGet("calculation/products/{type}/{fromdate}")]
    public async Task<IActionResult> GetPaymentCalculationByProducts(string type, string fromDate)
    {
        var response = await _client.GetPaymentCalculationByProducts(type, fromDate);

        var result = await response.Content.ReadFromJsonAsync<CalculationByProductsResult>();

        return Ok(result?.result[0].obracun_artikli);
    }
}
