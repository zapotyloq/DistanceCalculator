using DistanceCalculator.API.Controllers;
using DistanceCalculator.BLL.Services.Abstractions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.Tests.Controllers.Common
{
    public class ControllerTestsFixture : IDisposable
    {
        protected Mock<IDistanceService> distanceService;
        protected DistanceController distanceController;

        public ControllerTestsFixture() 
        {
            distanceService = new Mock<IDistanceService>();
            distanceController = new DistanceController(distanceService.Object);
        }

        public void Dispose()
        {
            distanceService = null;
            distanceController = null;
        }
    }
}
