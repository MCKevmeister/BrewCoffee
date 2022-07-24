using BrewCoffee.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Interfaces;

public interface ICoffeeService
{
    public Task<ActionResult<Coffee>> BrewCoffee();
}