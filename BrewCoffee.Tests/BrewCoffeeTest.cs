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