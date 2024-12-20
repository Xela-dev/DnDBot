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
    
    public async Task<string> GetItemByNameAsync(string path, string index)
    {
        var item = await findResourceItemByIndexAsync(path, index);

        if (item != null)
            return await getAsync(item.Url);
        
        return null;
    }

    public async Task<T> GetItemByNameAsync<T>(string path, string index)
    {
        var item = await findResourceItemByIndexAsync(path, index);

        if (item != null)
            return await GetAsync<T>(item.Url);
        
        return default;
    }
    
    public async Task<string> GetStrItemByNameAsync(string path, string index)
    {
        var item = await findResourceItemByIndexAsync(path, index);

        if (item != null)
            return await getAsync(item.Url);
        
        return default;
    }

    public async Task<string> GetResourcesByPathAsync(string path)
    {
        var response = await GetAsync<Feature>(path);
        List<String> resourceNames = new ();
        
        foreach (var resource in response.Results)
        {
            resourceNames.Add(resource.Name);
        }
        
        return JsonConvert.SerializeObject(resourceNames);
    }

    private async Task<ResourceItem> findResourceItemByIndexAsync(string path, string index)
    {
        var response = await GetAsync<Feature>(path);

        foreach (var item in response.Results)
            if (item.Index == index)
                return item;

        return null;
    }
    
    private async Task<string> getAsync(string url)
    {
        var path = url.Contains("/api") ? url : $"/api/{url}";
        var responseMessage = await client.GetAsync(path);

        if (responseMessage.IsSuccessStatusCode)
            return responseMessage.Content.ReadAsStringAsync().Result;

        return default;
    }
}