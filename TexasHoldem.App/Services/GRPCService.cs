using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using Poker.Grpc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TexasHoldem.App.Services
{
    public class GRPCService : IHostedService
    {
        private readonly MessageNotificationService _messageNotificationService;

        private Timer? _timer = null;

        public GRPCService(MessageNotificationService messageNotificationService)
        {
            _messageNotificationService = messageNotificationService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromMilliseconds(100));
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Game.GameClient(channel);
            var response = client.StartGame(new StartGameRequest());

            Task.Run(async () => _messageNotificationService.RaiseNotification(response));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
