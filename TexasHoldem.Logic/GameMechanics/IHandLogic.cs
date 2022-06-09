using System.Collections.Generic;
using TexasHoldem.Logic.Players;

namespace TexasHoldem.Logic.GameMechanics
{
    public interface IHandLogic
    {

        void Play();
        void PlayCustom();

        IEnumerable<IPlayer> GetPlayers();
    }
}
