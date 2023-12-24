using DistanceCalculator.BLL.Exceptions;
using DistanceCalculator.BLL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DistanceCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService distanceService;

        Regex IATARegex = new Regex("[A-Z]{3}$");

        public DistanceController(IDistanceService distanceService)
        {
            this.distanceService = distanceService;
        }

        [HttpGet("getDistanceInMiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDistanceInMilesAsync(string codeIATA1, string codeIATA2, CancellationToken cancelationToken)
        {
            if (!IATARegex.IsMatch(codeIATA1))
            {
                return BadRequest($"{codeIATA1} does not match the pattern.");
            }
            if (!IATARegex.IsMatch(codeIATA2))
            {
                return BadRequest($"{codeIATA2} does not match the pattern.");
            }
            try
            {
                var result = await distanceService.GetDistanceInMilesAsync(codeIATA1, codeIATA2, cancelationToken);
                return Ok(result);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
