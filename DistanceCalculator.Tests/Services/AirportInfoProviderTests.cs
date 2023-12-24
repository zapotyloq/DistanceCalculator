using DistanceCalculator.BLL.Exceptions;
using DistanceCalculator.BLL.Models;
using DistanceCalculator.Tests.Services.Common;
using Moq;
using Shouldly;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DistanceCalculator.Tests.Services
{
    public class AirportInfoProviderTests : ServiceTestsFixture
    {
        [Fact]
        public void GetAirportAsync_WithNotExistAirport_Throws_NotFound()
        {
            var codeIATA = "AWS";
            httpClient.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)));

            Assert.ThrowsAsync<NotFoundException>(() => airportInfoProvider.GetAirportAsync(codeIATA, CancellationToken.None));
        }

        [Fact]
        public void GetAirportAsync_WithExistAirport_Returns_AirportInfo()
        {
            var codeIATA = "AMS";
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent("{}");
            httpClient.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            var actual = airportInfoProvider.GetAirportAsync(codeIATA, CancellationToken.None).GetAwaiter().GetResult();

            actual.ShouldNotBeNull();
            actual.ShouldBeOfType(typeof(AirportInfo));
        }
    }
}
