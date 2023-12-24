namespace DistanceCalculator.BLL.Helpers
{
    public static class DistanceConverter
    {
        const double METERS_TO_MILES_COEFFICIENT = 0.000621371;
        public static double MetersToMiles(double meters)
        {
            return meters * METERS_TO_MILES_COEFFICIENT;
        }
    }
}
