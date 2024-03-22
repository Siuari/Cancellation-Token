using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace DataServerApi.Controllers;

[Route("teste")]
public class CancellationTokenTestController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public CancellationTokenTestController()
    {
        _httpClient = new HttpClient();
    }

    [HttpGet("propagando")]
    public async Task<IActionResult> TestePropagando(CancellationToken cancellationToken)
    {
        var url = new Uri("http://localhost:5182/cancellation-token/propagado");

        await _httpClient.GetAsync(url, cancellationToken);
        
        return Ok();
    }

    [HttpGet("nao-propagado")]
    public async Task<IActionResult> TesteNaoPropagando(CancellationToken cancellationToken)
    {
        var url = new Uri("http://localhost:5182/cancellation-token/nao-propagado");

        await _httpClient.GetAsync(url, cancellationToken);
        
        return Ok();
    }
}