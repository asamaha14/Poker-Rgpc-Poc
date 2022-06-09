namespace TexasHoldem.Logic.GameMechanics
{
    using System.Collections;
    using System.Collections.Generic;
    using TexasHoldem.Logic.Players;

    public interface ITexasHoldemGame
    {
        int HandsPlayed { get; }

        IPlayer Start();
       
        IEnumerable<IPlayer> StartGameCustom();
    }
}
