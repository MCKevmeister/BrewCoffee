using BrewCoffee.Interfaces;
using BrewCoffee.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Services;

public class CoffeeService : ICoffeeService
{
    private static int CoffeesMade { get; set; }

    public ActionResult BrewCoffee()
    {
        CoffeesMade++;
        return CoffeesMade switch
        {
            < 5 when DateTime.Now.Day == 1 && DateTime.Now.Month == 4 =>
                new StatusCodeResult(418),
            
            < 5 =>
                new OkObjectResult(new Coffee()),
            
            _ => new StatusCodeResult(503)
        };
    }
}