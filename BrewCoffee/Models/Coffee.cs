using System.Globalization;

namespace BrewCoffee.Models;

public class Coffee
{
    public string Message { get; set; }
    public string Prepared { get; set; }
    public Coffee(string message)
    {
        Message = message;
        Prepared = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
    }
}