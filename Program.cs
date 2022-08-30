using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ApiTest;

class Program
{
    static void Main(string[] args)
    {
        Task<string> apiCallTask = ApiHelper.ApiCall("jQtzwDO3kHjG2VsZrpYhRfNdtG9r9vYf");
        string result = apiCallTask.Result;
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());
        foreach (Article article in articleList)
        {
            Console.WriteLine($"Section: {article.Section}");
            Console.WriteLine($"Title: {article.Title}");
            Console.WriteLine($"Abstract: {article.Abstract}");
            Console.WriteLine($"Url: {article.Url}");
            Console.WriteLine($"Byline: {article.Byline}");
            Console.WriteLine("====================");
        }
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

