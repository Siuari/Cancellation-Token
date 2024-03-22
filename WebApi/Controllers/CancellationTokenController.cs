using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("cancellation-token")]
public class CancellationTokenController : ControllerBase
{
    [HttpGet("propagado")]
    public async Task<IActionResult> CancellationTokenPropagado(CancellationToken cancellationToken)
    {
        var segundos = 1;
        
        while (true)
        {
            Console.WriteLine(segundos++  + " Segundos");
            
            await Task.Delay(1000, cancellationToken);
            
            if(segundos > 10) break;
        }

        return Ok();
    }
    
    [HttpGet("nao-propagado")]
    public async Task<IActionResult> CancellationNaoTokenPropagado(CancellationToken cancellationToken)
    {
        var segundos = 1;
        
        while (true)
        {
            Console.WriteLine($"{segundos++} Segundos");
            
            await Task.Delay(1000);
            
            if(segundos > 10) break;
        }

        return Ok();
    }
    
    [HttpGet("controlado-manualmente")]
    public async Task<IActionResult> GetManualmente(CancellationToken cancellationToken)
    {
        var segundos = 1;
        
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"{segundos++} Segundos");
            
            await Task.Delay(1000);
            
            if(segundos > 10) break;
        }

        if (cancellationToken.IsCancellationRequested) Console.WriteLine("Requisição Cancelada");

        return Ok();
    }
}