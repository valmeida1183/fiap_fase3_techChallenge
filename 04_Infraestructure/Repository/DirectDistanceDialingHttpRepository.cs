using Core.Entity;
using Core.Repository.Interface;
using Infraestructure.Repository.Base;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Infraestructure.Repository;
public class DirectDistanceDialingHttpRepository : BaseHttpRepository<DirectDistanceDialing>, IDirectDistanceDialingHttpRepository
{
    public DirectDistanceDialingHttpRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "persistence-api/v1/ddd")
    {
    }
}
