using RestAPITest.DTO;
using System.Diagnostics;

namespace RestAPITest.Services
{
    public interface IBetService
    {
        public Task<BetDTO> GetBet();
        public Task PostBet(BetDTO bet);
    }

    public class BetService : IBetService
    {
        private Stopwatch? _stopwatch;

        public async Task<BetDTO> GetBet()
        {
            if (_stopwatch == null)
            {
                _stopwatch = Stopwatch.StartNew();
            }
            else
            {
                while (_stopwatch.ElapsedMilliseconds < 90000)
                {
                    await Task.Delay(500);
                }
            }

            _stopwatch.Restart();

            return new BetDTO()
            {

            };
        }

        public async Task PostBet(BetDTO bet)
        {
            throw new NotImplementedException();
        }
    }
}
