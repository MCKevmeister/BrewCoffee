using BrewCoffee.Interfaces;
using BrewCoffee.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Services;

public class CoffeeService : ICoffeeService
{
    private static int CoffeesMade { get; set; }

    public Task<ActionResult<Coffee>> BrewCoffee()
    {
        CoffeesMade++;
        return CoffeesMade < 5
            ? Task.FromResult<ActionResult<Coffee>>(new OkObjectResult(new Coffee()))
            : Task.FromResult<ActionResult<Coffee>>(new StatusCodeResult(503));
    }
}