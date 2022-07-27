using BrewCoffee.Controllers;
using BrewCoffee.Interfaces;
using BrewCoffee.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BrewCoffee.Xunit.Tests;

public class BrewCoffee
{
    private static Mock<ICoffeeService> CoffeeServiceMock()
    {
        var coffeeServiceMock = new Mock<ICoffeeService>();
        coffeeServiceMock
            .SetupSequence(x => x.BrewCoffee())
            .Returns(new OkObjectResult(new Coffee()))
            .Returns(new OkObjectResult(new Coffee()))
            .Returns(new OkObjectResult(new Coffee()))
            .Returns(new OkObjectResult(new Coffee()))
            .Returns(new StatusCodeResult(503));
        return coffeeServiceMock;
    }


    [Fact]
    public async Task Get_BrewCoffee_Returns200()
    {
        // Arrange
        var coffeeServiceMock = CoffeeServiceMock();
        var sut = new CoffeeController(coffeeServiceMock.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    // Get brew coffee on success Invokes Coffee Service
    [Fact]
    public async Task Get_BrewCoffee_OnSuccessInvokesCoffeeService()
    {
        // Arrange
        var coffeeServiceMock = CoffeeServiceMock();
        var sut = new CoffeeController(coffeeServiceMock.Object);

        // Act
        await sut.Get();

        // Assert
        coffeeServiceMock.Verify(x => x.BrewCoffee(), Times.Once);
    }

    // get brew coffee on success returns coffee
    [Fact]
    public async Task Get_BrewCoffee_OnSuccessReturnsCoffee()
    {
        // Arrange
        var coffeeServiceMock = CoffeeServiceMock();
        var sut = new CoffeeController(coffeeServiceMock.Object);

        // Act
        var result = await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        ((OkObjectResult)result).Value.Should().BeOfType<Coffee>();
    }

    // On every fifth call to /brew-coffee, return a 503 error
    [Fact]
    public async Task Get_BrewCoffee_OnEveryFifthCallReturns503()
    {
        // Arrange
        var coffeeServiceMock = CoffeeServiceMock();
        var sut = new CoffeeController(coffeeServiceMock.Object);
        for (var i = 0; i < 4; i++)
        {
            await sut.Get();
        }
        
        // Act
        var fifthCall = await sut.Get();

        // Assert
        ((StatusCodeResult)fifthCall).StatusCode.Should().Be(503);
    }
}