using BrewCoffee.Interfaces;
using BrewCoffee.Models;

namespace BrewCoffee.Services;

public class CoffeeService:ICoffeeService
{
    public Task<Coffee> BrewCoffee()
    {
        return Task.FromResult(new Coffee("Your piping hot coffee is ready"));
    }
}