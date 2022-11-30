using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WFB.Services;

Console.WriteLine("Hello, Browser!");

public partial class MyClass
{
    private static readonly HttpClient Client = new();

    [JSExport]
    internal static int PickANumber()
    {
        return AwesomeService.GetRandomNumber();
    }

    [JSExport]
    internal static async Task<string> ComputeHash()
    {
        var currentNumber = GetCurrentNumber();
        var url = $"http://localhost:3000?number={currentNumber}";
        var result = await Client.GetFromJsonAsync<HashResult>(url);
        return result?.Hash;
    }

    [JSImport("number", "main.js")]
    internal static partial int GetCurrentNumber();
}

public record HashResult
{
    [JsonPropertyName("hash")] public string Hash { get; set; }
}