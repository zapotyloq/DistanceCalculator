using DistanceCalculator.BLL.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Abstractions
{
    public interface IAirportInfoProvider
    {
        Task<AirportInfo> GetAirportAsync(string codeIATA, CancellationToken cancellationToken);
    }
}
