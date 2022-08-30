using RestSharp;

namespace ApiTest;

class Program
{
    static void Main()
    {
        Task<string> apiCallTask = ApiHelper.ApiCall("jQtzwDO3kHjG2VsZrpYhRfNdtG9r9vYf");
        string result = apiCallTask.Result;
        Console.WriteLine(result);
    }
}

class ApiHelper
{
    public static async Task<string> ApiCall(string apiKey)
    {
        var client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
        var request = new RestRequest($"home.json?api-key={apiKey}", Method.Get);
        var response = await client.ExecuteAsync(request);
        return response.Content;
    }
}

