using BrewCoffee.Models;

namespace BrewCoffee.Interfaces;

public interface ICoffeeService
{
    public Task<Coffee> BrewCoffee();
}