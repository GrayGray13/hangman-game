using System.Text.Json;

namespace HangmanApp;

public class RandomWord
{
    private static readonly HttpClient Client = new HttpClient();
    
    public static async Task<string?> GetRandomWord()
    {
        try
        {
            var responseBody = await Client.GetStringAsync("https://random-word-api.herokuapp.com/word");
            var randomWord = JsonSerializer.Deserialize<string[]>(responseBody);
            return randomWord?[0];
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }
}