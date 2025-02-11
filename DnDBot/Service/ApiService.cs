using System.Net;
using System.Net.Http.Headers;
using DnDBot.Model;
using Newtonsoft.Json;

namespace DnDBot.Service;

public class ApiService
{
    private readonly HttpClient client;
    private readonly string url = "https://www.dnd5eapi.co/api";

    public ApiService()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<T> GetAsync<T>(Uri uri)
    {
        var response = await getAsync(uri);
        return String.IsNullOrEmpty(response) ? default : JsonConvert.DeserializeObject<T>(response);
    }
    
    public async Task<string> GetAsync(Uri uri)
    {
        return await getAsync(uri);
    }
    
    public async Task<string> GetItemByNameAsync(string path, string index)
    {
        var uri = getUri($"/{path}/{index}");
        return await GetAsync(uri);
    }

    public async Task<T> GetItemByNameAsync<T>(string path, string index)
    {
        var uri = getUri($"/{path}/{index}");
        return await GetAsync<T>(uri);
    }

    public async Task<string> GetResourcesByPathAsync(string path)
    {
        var uri = getUri($"/{path}");
        var response = await GetAsync<Feature>(uri);
        List<String> resourceNames = new ();
        
        foreach (var resource in response.Results)
            resourceNames.Add(resource.Name);
        
        return JsonConvert.SerializeObject(resourceNames);
    }
    private Uri getUri(string path) => new Uri(url + path);
    
    private async Task<string> getAsync(Uri uri)
    {
        try
        {
            var responseMessage = await client.GetAsync(uri);
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode == HttpStatusCode.OK)
                return responseString;
            
            throw new HttpRequestException(responseString);
        }
        catch (Exception e)
        {
            throw new Exception($"Error: {e.Message}");
        }
    }
}