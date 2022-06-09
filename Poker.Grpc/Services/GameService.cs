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
            IEnumerable<IPlayer> result = StartPokerGameInternal();

            // Map Response
            StartGameResponse response = GetGameResponse(result);

            return Task.FromResult(response);
        }

        private StartGameResponse GetGameResponse(IEnumerable<IPlayer> result)
        {
            var response = new StartGameResponse();
            RepeatedField<Player> playersToReturn = new RepeatedField<Player>();

            foreach (var tempPlayer in result)
            {
                var player = this.MapToPlayer(tempPlayer);
                playersToReturn.Add(player);
            }

            response.Players.Add(playersToReturn);
            return response;
        }

        private static IEnumerable<IPlayer> StartPokerGameInternal()
        {
            var players = new List<IPlayer>();

            players.Add(new InnovationDayPlayer("ABS"));
            players.Add(new InnovationDayPlayer("Fatma"));
            players.Add(new InnovationDayPlayer("Nico"));

            var game = new TexasHoldemGame(players);
            var result = game.StartGameCustom();
            return result;
        }

        private Player MapToPlayer(IPlayer player)
        {
            RepeatedField<Card> mappedCards = new RepeatedField<Card>();
            foreach (var card in player.Cards)
            {
                mappedCards.Add(new Card()
                {
                    CardSuit = (CardSuit)card.Suit,
                    CardType = (CardType)card.Type
                });
            }

            var mappedPlayer = new Player()
            {
                Name = player.Name,
                BuyIn = player.BuyIn,

            };
            mappedPlayer.Cards.Add(mappedCards);

            return mappedPlayer;
        }

    }
}
