using Grpc.Core;
using System.Threading.Tasks;

namespace Poker.Grpc.Services
{
    public class GameService : Game.GameBase
    {
        public override Task<StartGameResponse> StartGame(StartGameRequest request, ServerCallContext context)
        {
            var response = new StartGameResponse();
            return response;


        }
    }
}
