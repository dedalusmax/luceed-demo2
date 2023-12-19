using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace LuceedDemo.Server.Config;

public class LuceedApiClient 
{
    private readonly HttpClient _httpClient;

    public LuceedApiClient(HttpClient httpClient, IOptions<LuceedApiOptions> apiOptions)
    {
        var options = apiOptions.Value;
        var token = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{options.Username}:{options.Password}"));

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(options.Endpoint)
        };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
    }

    public async Task<HttpResponseMessage> GetArticlesByNameAsync(string name) => await _httpClient.GetAsync($"artikli/naziv/{name}/[0,5]"); // paging shouldn't fixed, but it's an only example

    public async Task<HttpResponseMessage> GetPaymentCalculationByPaymentType(string type, string fromDate) => await _httpClient.GetAsync($"mpobracun/placanja/{type}/{fromDate}");

    public async Task<HttpResponseMessage> GetPaymentCalculationByProducts(string type, string fromDate) => await _httpClient.GetAsync($"mpobracun/artikli/{type}/{fromDate}");
}
