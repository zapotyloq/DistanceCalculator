using DistanceCalculator.BLL.Services.Abstractions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Implementations
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync(requestUri);
        }
    }
}
