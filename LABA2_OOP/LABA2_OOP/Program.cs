using System.Text.Json;
class Program
{
    static async Task Main(string[] args)
    {
        var urls = new List<string>
        {
            "https://api.hh.ru/openapi/redoc#section/Obshaya-informaciya/Vybor-s",
             "https://jsonplaceholder.typicode.com/posts/1",
            "https://jsonplaceholder.typicode.com/posts/2",
            "https://jsonplaceholder.typicode.com/posts/3"
        };

        var httpClient = new HttpClient();
        var tasks = new List<Task<string>>();

        var startTime = DateTime.Now;

        foreach (var url in urls)
        {
            tasks.Add(FetchData(httpClient, url));
        }

        var responses = await Task.WhenAll(tasks);

        foreach (var response in responses)
        { 
            var jsonContent = JsonSerializer.Serialize(response);
            Console.WriteLine(response);
        }

        var endTime = DateTime.Now;
        var totalTime = endTime - startTime;
        Console.WriteLine($"Total execution time: {totalTime}");    
    }

    static async Task<string> FetchData(HttpClient httpClient, string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Error fetching data from {url}: {ex.Message}");
        }
    }
}
