using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Controllers;

[ApiController]
[Route("brew-coffee")]
public class CoffeeController: ControllerBase
{
    public CoffeeController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}