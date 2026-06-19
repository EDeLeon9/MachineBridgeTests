using Microsoft.AspNetCore.Mvc;
using RestAPITest.DTO;
using RestAPITest.Services;

namespace RestAPITest.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpGet("bet/analyze")]
        public async Task<ActionResult<BetDTO>> GetBet()
        {
            var bet = await _betService.GetBet();
            return Ok(bet);
        }

        [HttpPost("webhook/round/{roundID}/result")]
        public IActionResult PostBet(string roundID, [FromBody] BetDTO bet)
        {
            if (bet != null)
            {
                _betService.PostBet(bet);
                return Ok(new { message = "Bet result received." });
            }
            return BadRequest(new { message = "Bet payload is required." });
        }
    }
}
