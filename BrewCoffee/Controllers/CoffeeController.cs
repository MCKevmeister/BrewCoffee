using BrewCoffee.Interfaces;
using BrewCoffee.Models;
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
    public Task<ActionResult<Coffee>> Get()
    {
        var coffee =  _coffeeService.BrewCoffee();
        return Task.FromResult<ActionResult<Coffee>>(Ok(coffee));
        
    }
}