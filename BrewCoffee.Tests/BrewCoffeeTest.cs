using BrewCoffee.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BrewCoffee.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetBrewCoffee_Returns200()
    {
        // Arrange
        var sut = new CoffeeController();

        // Act
        var result = await sut.Get();

        // Assert
        Assert.That(result, Is.TypeOf<OkResult>());
    }
}