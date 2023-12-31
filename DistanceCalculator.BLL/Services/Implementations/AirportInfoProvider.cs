﻿using DistanceCalculator.BLL.Exceptions;
using DistanceCalculator.BLL.Models;
using DistanceCalculator.BLL.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Implementations
{
    public class AirportInfoProvider : IAirportInfoProvider
    {
        private readonly string AIRPORT_PROVIDER_API_URL;
        private readonly IHttpClientWrapper httpClient;

        public AirportInfoProvider(IConfiguration configuration, IHttpClientWrapper httpClient) {
            this.httpClient = httpClient;
            AIRPORT_PROVIDER_API_URL = configuration["airpotsAPI"];
        }

        public async Task<AirportInfo> GetAirportAsync(string codeIATA, CancellationToken cancellationToken)
        {
            var url = AIRPORT_PROVIDER_API_URL + codeIATA;
            var response = await httpClient.GetAsync(url, cancellationToken);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException($"Airport {codeIATA} is not exists.");
            }
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var airportInfo = JObject.Parse(content).ToObject<AirportInfo>();
            return airportInfo;
        }
    }
}
