using OmedaCity;
using OmedaCity.Models;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var result = await OmedaCityClientApi.GetMatchById("");
            Console.WriteLine(result.Players);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
        }
       
        Console.ReadKey();
    }
}