using DistanceCalculator.BLL.Services.Abstractions;
using DistanceCalculator.BLL.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Net.Http;

namespace DistanceCalculator.Tests.Services.Common
{
    public class ServiceTestsFixture : IDisposable
    {
        protected Mock<IConfiguration> config;
        protected Mock<IHttpClientWrapper> httpClient;

        protected Mock<IAirportInfoProvider> airportInfoProviderMocked;

        protected DistanceService distanceService;
        protected AirportInfoProvider airportInfoProvider;

        public ServiceTestsFixture()
        {
            config = new Mock<IConfiguration>();
            httpClient = new Mock<IHttpClientWrapper>();

            airportInfoProviderMocked = new Mock<IAirportInfoProvider>();

            airportInfoProvider = new AirportInfoProvider(config.Object, httpClient.Object);
            distanceService = new DistanceService(airportInfoProviderMocked.Object);
        }

        public void Dispose()
        {
            config = null;
            httpClient = null;

            airportInfoProviderMocked = null;

            airportInfoProvider = null;
            distanceService = null;
        }
    }
}
