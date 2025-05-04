using Core.Entity;
using Core.Entity.Base;
using Core.Repository.Interface;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infraestructure.Repository.Base;
public abstract class BaseHttpRepository<T> : IHttpRepository<T> where T : BaseEntity
{
    protected readonly HttpClient _httpClient;
    protected readonly string _baseUrl;    
    protected readonly string _url; 

    public BaseHttpRepository(
        HttpClient httpClient, 
        IOptions<PersistanceApiUrlsOptions> options,
        string endpoint)
    {
        _httpClient = httpClient;
        _baseUrl = options.Value.Https;
        _url = $"{_baseUrl}/{endpoint}";
    }
    public async Task<IList<T>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<T>>(_url);

        return result is null ? new List<T>() : result;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var url = $"{_url}/{id}";
        return await _httpClient.GetFromJsonAsync<T>(url);
    }

    public async Task CreateAsync(T entity)
    {
        var response = await _httpClient.PostAsJsonAsync(_url, entity);
        response.EnsureSuccessStatusCode();
    }

    public async Task EditAsync(T entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_url}/{entity.Id}", entity);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(T entity)
    {
        var response = await _httpClient.DeleteAsync($"{_url}/{entity.Id}");
        response.EnsureSuccessStatusCode();
    }
}
