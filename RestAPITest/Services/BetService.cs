using System;
using System.Diagnostics;
using System.Text.Json;
using RestAPITest.DTO;

namespace RestAPITest.Services
{
    public interface IBetService
    {
        public Task<BetDTO> GetBet();
        public void PostBet(BetDTO bet);
    }

    public class BetService : IBetService
    {
        private Stopwatch? _stopwatch;

        public async Task<BetDTO> GetBet()
        {
            BetDTO betResult;
            if (_stopwatch == null || _stopwatch.ElapsedMilliseconds >= 60000)
            {
                betResult = new BetDTO()
                {
                    Success = true,
                    RoundNumber = 10208,
                    Box1 = new BoxDTO() { LessParity = "odd" },
                    Box2 = new BoxDTO() { LessParity = "even" },
                };
                if (_stopwatch == null)
                    _stopwatch = Stopwatch.StartNew();
                else
                    _stopwatch.Restart();

            }
            else
            {
                betResult = new BetDTO()
                {
                    Success = true,
                    Message = "No current bets."
                };
            }

            return betResult;
        }

        public void PostBet(BetDTO bet)
        {
            Console.WriteLine(JsonSerializer.Serialize(bet));
        }
    }
}
