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
        switch (CoffeesMade)
        {
            case < 5 when DateTime.Now.Day == 1 && DateTime.Now.Month == 4:
                return Task.FromResult<ActionResult<Coffee>>(new StatusCodeResult(418));
            case < 5:
                return Task.FromResult<ActionResult<Coffee>>(new OkObjectResult(new Coffee()));
            default:
                return Task.FromResult<ActionResult<Coffee>>(new StatusCodeResult(503));
        }
    }
}