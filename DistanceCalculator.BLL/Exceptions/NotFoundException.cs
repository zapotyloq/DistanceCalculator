using System;

namespace DistanceCalculator.BLL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {
        }
    }
}
