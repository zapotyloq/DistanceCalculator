using DistanceCalculator.BLL.Models;
using DistanceCalculator.Tests.Services.Common;
using Moq;
using Shouldly;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using DistanceCalculator.BLL.Exceptions;
using DistanceCalculator.Tests.Common;

namespace DistanceCalculator.Tests.Services
{
    public class DistanceServiceTests : ServiceTestsFixture
    {
        [Fact]
        public void GetDistanceInMilesAsync_WithIncorrectCode_Throws_NotFound()
        {
            var codeIATA1 = "AMS";
            var codeIATA2 = "AWS";
            airportInfoProviderMocked.Setup(x => x.GetAirportAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new NotFoundException(string.Empty));

            Assert.ThrowsAsync<NotFoundException>(() => distanceService.GetDistanceInMilesAsync(codeIATA1, codeIATA2, CancellationToken.None));
        }

        [Fact]
        public void GetDistanceInMilesAsync_WithCorrectCode_Returns_Double()
        {
            var codeIATA1 = "AMS";
            var codeIATA2 = "AWS";
            airportInfoProviderMocked.Setup(x => x.GetAirportAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(SampleEntites.GetAMDAirportInfo()));

            var actual = distanceService.GetDistanceInMilesAsync(codeIATA1, codeIATA2, CancellationToken.None).GetAwaiter().GetResult();

            actual.ShouldNotBeNull();
            actual.ShouldBeOfType(typeof(double));
        }
    }
}
