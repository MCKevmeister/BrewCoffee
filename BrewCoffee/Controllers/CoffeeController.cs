using BrewCoffee.Interfaces;
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
    public Task<IActionResult> Get()
    {
        var coffee =  _coffeeService.BrewCoffee();
        return Task.FromResult<IActionResult>(Ok(coffee));
    }
}