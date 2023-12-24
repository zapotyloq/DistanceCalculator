using DistanceCalculator.BLL.Models;

namespace DistanceCalculator.Tests.Common
{
    public static class SampleEntites
    {
        public static AirportInfo GetAMSAirportInfo()
        {
            return new AirportInfo
            {
                IATA = "AMS",
                Name = "Amsterdam",
                Location = new Location
                {
                    Lat = 52.309069,
                    Lon = 4.763385
                }
            };
        }
        public static AirportInfo GetAMDAirportInfo()
        {
            return new AirportInfo
            {
                IATA = "AMD",
                Name = "Ahmedabad",
                Location = new Location
                {
                    Lat = 23.066389,
                    Lon = 72.624167
                }
            };
        }
    }
}
