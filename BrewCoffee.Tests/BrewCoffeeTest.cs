using System.Diagnostics;
using System.Net;
using BrewCoffee.Controllers;
using BrewCoffee.Interfaces;
using BrewCoffee.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BrewCoffee.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Get_BrewCoffee_Returns200()
    {
        // Arrange
        var coffeeServiceMock = new Mock<ICoffeeService>();
        coffeeServiceMock
            .Setup(x => x.BrewCoffee())
            .Returns(Task.FromResult(new ActionResult<Coffee>(new Coffee())));
        var sut = new CoffeeController(coffeeServiceMock.Object);

        // Act
        var result = await sut.Get();

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }

    // Get brew coffee on success Invokes Coffee Service
    [Test]
    public async Task Get_OnSuccess_InvokesCoffeeService()
    {
        // Arrange
        var coffeeServiceMock = new Mock<ICoffeeService>();
        coffeeServiceMock
            .Setup(x => x.BrewCoffee())
            .Returns(Task.FromResult(new ActionResult<Coffee>(new Coffee())));
        
        var sut = new CoffeeController(coffeeServiceMock.Object);
        
        // Act
        await sut.Get().ConfigureAwait(false);
        
        // Assert
        coffeeServiceMock.Verify(x => x.BrewCoffee(), Times.Once);
    }

    // On every fifth call to /brew-coffee, return a 503 error
    [Test]
    public void Get_OnEveryFifthCall_Returns503()
    {
        // Arrange
        var coffeeServiceMock = new Mock<ICoffeeService>();
        coffeeServiceMock
            .Setup(x => x.BrewCoffee())
            .Returns(Task.FromResult(new ActionResult<Coffee>(new Coffee())));

        var sut = new CoffeeController(coffeeServiceMock.Object);

        // Act
        for (var i = 0; i < 5; i++)
        {
            sut.Get().ConfigureAwait(false);
        }
        var result = sut.Get();

        // Assert
        Assert.That(result, Is.TypeOf<StatusCodeResult>());
    }
}