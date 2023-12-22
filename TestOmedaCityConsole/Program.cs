using OmedaCity;
using OmedaCity.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var result = await OmedaCityClientApi.GetPlayerById("sdasda");
            Console.WriteLine(result.DisplayName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
       
        Console.ReadKey();
    }
}