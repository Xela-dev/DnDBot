using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using DnDBot.Model;
using Newtonsoft.Json;

namespace DnDBot.Service;

public class ApiService
{
    private readonly HttpClient client;
    private string url = "https://www.dnd5eapi.co";

    public ApiService()
    {
        client = new HttpClient { BaseAddress = new Uri(url) };
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<T> GetAsync<T>(string path)
    {
        var response = await getAsync(path);
        return String.IsNullOrEmpty(response) ? default : JsonConvert.DeserializeObject<T>(response);
    }
    
    public async Task<string> GetAsync(string path)
    {
        return await getAsync(path);
    }
    
    public async Task<string> GetItemByNameAsync(string path, string index)
    {
        var url = $"/api/{path}/{index}";
        return await GetAsync(url);
    }

    public async Task<T> GetItemByNameAsync<T>(string path, string index)
    {
        var url = $"/api/{path}/{index}";
        return await GetAsync<T>(url);
    }

    public async Task<string> GetResourcesByPathAsync(string path)
    {
        var response = await GetAsync<Feature>(path);
        List<String> resourceNames = new ();
        
        foreach (var resource in response.Results)
            resourceNames.Add(resource.Name);
        
        return JsonConvert.SerializeObject(resourceNames);
    }
    
    private async Task<string> getAsync(string path)
    {
        try
        {
            var responseMessage = await client.GetAsync(path);
            return await responseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {
            throw new Exception("");
        }
    }
}