using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Abstractions
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken);
    }
}
