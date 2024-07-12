using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private ValueDto ValueDto { get; } = new();

    public TransientService TransientService { get; }
    public ScopedService ScopedService { get; }
    public SingletonService SingletonService { get; }

    public ValuesController(
        TransientService transientService,
        ScopedService scopedService,
        SingletonService singletonService
        ) 
    {
        TransientService = transientService;
        ScopedService = scopedService;
        SingletonService = singletonService;
    }


    [HttpPost("actiona")]
    public async Task<IEnumerable<ValueDto>> ActionA()
    {
        foreach  (var v in Enumerable.Repeat(1, 50))
        {
            ValueDto.Value += v;
            TransientService.ValueDto.Value += v;
            ScopedService.ValueDto.Value += v;
            SingletonService.ValueDto.Value += v;

            await Task.Delay(300);
        }

        return [
            ValueDto,
            TransientService.ValueDto,
            ScopedService.ValueDto,
            SingletonService.ValueDto
        ];
    }

    [HttpPost("actionb")]
    public async Task<IEnumerable<ValueDto>> ActionB()
    {
        foreach (var v in Enumerable.Repeat(10, 50))
        {
            ValueDto.Value += v;
            TransientService.ValueDto.Value += v;
            ScopedService.ValueDto.Value += v;
            SingletonService.ValueDto.Value += v;

            await Task.Delay(300);
        }

        return [
            ValueDto,
            TransientService.ValueDto,
            ScopedService.ValueDto,
            SingletonService.ValueDto
        ];
    }
}
