namespace TexasHoldem.Logic.Players
{
    public class InnovationDayPlayer : BasePlayer
    {
        public InnovationDayPlayer(string name)
        {
            this.Name = name;
        }

        public override string Name { get; }

        public override int BuyIn { get; } = 500;

        public override PlayerAction GetTurn(IGetTurnContext context)
        {
            return PlayerAction.CheckOrCall();
        }

        public override PlayerAction PostingBlind(IPostingBlindContext context)
        {
            return PlayerAction.CheckOrCall();
        }
    }
}
