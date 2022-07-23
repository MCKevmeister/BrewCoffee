using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Controllers;

[ApiController]
[Route("brew-coffee")]
public class CoffeeController: ControllerBase
{
    private readonly ICoffeeService _coffeeService;

    public CoffeeController(ICoffeeService coffeeService)
    {
        _coffeeService = coffeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var coffee = _coffeeService.BrewCoffee();
        return Ok(coffee);
    }
}

public interface ICoffeeService
{
    public Task<Coffee> BrewCoffee();
}

public class CoffeeService:ICoffeeService
{
    public Task<Coffee> BrewCoffee()
    {
        return Task.FromResult(new Coffee("Your piping hot coffee is ready"));
    }
}

public class Coffee
{
    private string Message { get; set; }
    private DateTime Prepared { get; set; }
    public Coffee(string message)
    {
        Message = message;
        Prepared = DateTime.Now;
    }
}