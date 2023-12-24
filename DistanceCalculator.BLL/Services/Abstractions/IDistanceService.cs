using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.BLL.Services.Abstractions
{
    public interface IDistanceService
    {
        Task<double> GetDistanceInMilesAsync(string codeIATA1, string codeIATA2, CancellationToken cancellationToken);
    }
}
