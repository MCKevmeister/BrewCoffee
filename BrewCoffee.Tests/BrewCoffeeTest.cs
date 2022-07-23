using BrewCoffee.Controllers;
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
            .Returns(Task.FromResult(new Coffee("Coffee")));
        
        var sut = new CoffeeController(coffeeServiceMock.Object);
        
        // Act
        await sut.Get().ConfigureAwait(false);
        
        // Assert
        coffeeServiceMock.Verify(x => x.BrewCoffee(), Times.Once);
    }
}