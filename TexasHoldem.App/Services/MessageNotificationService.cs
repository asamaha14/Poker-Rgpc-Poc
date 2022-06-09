using Poker.Grpc;
using System;
using System.Threading.Tasks;

namespace TexasHoldem.App.Services
{
    public class MessageNotificationService
    {
        public async Task RaiseNotification(StartGameResponse message) 
        {
            if (Notify != null)
            {
                await Notify.Invoke(message);
            }
        }

        public event Func<object, Task> Notify;
    }
}
