using Microsoft.AspNetCore.Components;
using Poker.Grpc;
using System.Threading.Tasks;
using TexasHoldem.App.Services;

namespace TexasHoldem.App.Pages
{
    public partial class Poc
    {
        [Inject]
        private MessageNotificationService MessageNotificationService { get; set; }

        private int MessageReceived = 0;

        private StartGameResponse _response = null;

        /// <summary>
        /// 
        /// </summary>
        protected override void OnInitialized()
        {
            MessageNotificationService.Notify += OnNotify;
            Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            MessageNotificationService.Notify -= OnNotify;
        }

        private void Refresh()
        {
            MessageReceived++;
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task OnNotify(object message)
        {
            await InvokeAsync(() =>
            {
                _response = message as StartGameResponse;

                Refresh();
            });
        }

        public string GetFilenameFromCard(Card card)
        {
            return $"{card.CardSuit}_{card.CardType}.png";
        }
    }
}
