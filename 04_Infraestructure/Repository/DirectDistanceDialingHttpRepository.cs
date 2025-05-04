using Core.Entity;
using Core.Repository.Interface;
using Infraestructure.Repository.Base;
using Microsoft.Extensions.Options;

namespace Infraestructure.Repository;
public class DirectDistanceDialingHttpRepository : BaseHttpRepository<DirectDistanceDialing>, IDirectDistanceDialingHttpRepository
{
    public DirectDistanceDialingHttpRepository(HttpClient httpClient, IOptions<PersistanceApiUrlsOptions> options) : base(httpClient, options, "persistence-api/v1/ddd")
    {
    }
}
