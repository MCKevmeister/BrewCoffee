namespace BrewCoffee.Models;

public class Coffee
{
    private string Message { get; set; }
    private DateTime Prepared { get; set; }
    public Coffee(string message)
    {
        Message = message;
        Prepared = DateTime.Now;
    }
}