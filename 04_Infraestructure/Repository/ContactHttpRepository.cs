using Core.Entity;
using Core.Repository.Interface;
using Infraestructure.Repository.Base;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infraestructure.Repository;
public class ContactHttpRepository : BaseHttpRepository<Contact>, IContactHttpRepository
{
    public ContactHttpRepository(HttpClient httpClient, IOptions<PersistanceApiUrlsOptions> options) 
        : base(httpClient, options, "persistence-api/v1/contacts")
    {        
    }

    public async Task<IList<Contact>> GetAllByDddAsync(int dddId)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Contact>>($"{_url}/ddd-code/{dddId}");

        return result is null ? new List<Contact>() : result;
    }
}
