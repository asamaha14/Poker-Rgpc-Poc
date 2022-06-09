using Google.Protobuf.Collections;
using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using TexasHoldem.Logic.GameMechanics;
using TexasHoldem.Logic.Players;

namespace Poker.Grpc.Services
{
    public class GameService : Game.GameBase
    {
        public override Task<StartGameResponse> StartGame(StartGameRequest request, ServerCallContext context)
        {
            // Call Game
            var players = new List<IPlayer>();

            players.Add(new InnovationDayPlayer("ABS"));
            players.Add(new InnovationDayPlayer("Fatma"));
            players.Add(new InnovationDayPlayer("Nico"));

            var game = new TexasHoldemGame(players);
            var result = game.StartGameCustom();


            // Map Response
            var response = new StartGameResponse();
            RepeatedField<Player> playersToReturn = new RepeatedField<Player>();

            foreach (var tempPlayer in result)
            {
                var player = this.MapToPlayer(tempPlayer);
                playersToReturn.Add(player);
            }

            response.Players.Add(playersToReturn);
            return Task.FromResult(response);
        }

        private Player MapToPlayer(IPlayer player)
        {
            return new Player()
            {
                Name = player.Name,
                BuyIn = player.BuyIn,

            };
        }

    }
}
