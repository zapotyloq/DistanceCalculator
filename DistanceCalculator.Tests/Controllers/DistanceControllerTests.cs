using DistanceCalculator.BLL.Exceptions;
using DistanceCalculator.Tests.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DistanceCalculator.Tests.Controllers
{
    public class DistanceControllerTests : ControllerTestsFixture
    {
        [Fact]
        public void GetDistanceInMilesAsync_WithValidData_Returns_OkResultAndDouble()
        {
            var codeIATA1 = "AMS";
            var codeIATA2 = "AMD";
            distanceService.Setup(x => x.GetDistanceInMilesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(1d));

            var response = distanceController.GetDistanceInMilesAsync(codeIATA1, codeIATA2, CancellationToken.None).GetAwaiter().GetResult();

            response.ShouldNotBeNull();
            response.ShouldBeOfType(typeof(OkObjectResult));
            ((OkObjectResult)response).Value.ShouldNotBeNull();
            ((OkObjectResult)response).Value.ShouldBeOfType(typeof(double));
        }

        [Fact]
        public void GetDistanceInMilesAsync_WithIncorrectCode_Returns_BadRequest()
        {
            var codeIATA1 = "AMS2";
            var codeIATA2 = "AMD";
            distanceService.Setup(x => x.GetDistanceInMilesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(1d));

            var response = distanceController.GetDistanceInMilesAsync(codeIATA1, codeIATA2, CancellationToken.None).GetAwaiter().GetResult();

            response.ShouldNotBeNull();
            response.ShouldBeOfType(typeof(BadRequestObjectResult));
            ((BadRequestObjectResult)response).Value.ShouldNotBeNull();
            ((BadRequestObjectResult)response).Value.ShouldBeOfType(typeof(string));
        }

        [Fact]
        public void GetDistanceInMilesASync_WithNotExistCode_Returns_NotFound()
        {
            var codeIATA1 = "AWS";
            var codeIATA2 = "AMD";
            distanceService.Setup(x => x.GetDistanceInMilesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new NotFoundException(string.Empty));

            var response = distanceController.GetDistanceInMilesAsync(codeIATA1, codeIATA2, CancellationToken.None).GetAwaiter().GetResult();

            response.ShouldNotBeNull();
            response.ShouldBeOfType(typeof(NotFoundObjectResult));
            ((NotFoundObjectResult)response).Value.ShouldNotBeNull();
            ((NotFoundObjectResult)response).Value.ShouldBeOfType(typeof(string));
        }
    }
}
