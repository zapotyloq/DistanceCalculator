using DistanceCalculator.BLL.Helpers;
using DistanceCalculator.BLL.Services.Abstractions;
using GeoCoordinatePortable;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Implementations
{
    public class DistanceService : IDistanceService
    {
        public IAirportInfoProvider airportInfoProvider;
        public DistanceService(IAirportInfoProvider airportInfoProvider) {
            this.airportInfoProvider = airportInfoProvider;
        }
        public async Task<double> GetDistanceInMilesAsync(string codeIATA1, string codeIATA2, CancellationToken cancellationToken)
        {
            var airportInfo1 = airportInfoProvider.GetAirportAsync(codeIATA1, cancellationToken);
            var airportInfo2 = airportInfoProvider.GetAirportAsync(codeIATA2, cancellationToken);

            await Task.WhenAll(airportInfo1, airportInfo2);

            GeoCoordinate coordinate1 = new GeoCoordinate(airportInfo1.Result.Location.Lat, airportInfo1.Result.Location.Lon);
            GeoCoordinate coordinate2 = new GeoCoordinate(airportInfo2.Result.Location.Lat, airportInfo2.Result.Location.Lon);

            double distanceBetween = coordinate1.GetDistanceTo(coordinate2);
            double distanceBetweenInMiles = DistanceConverter.MetersToMiles(distanceBetween);

            return distanceBetweenInMiles;
        }
    }
}
