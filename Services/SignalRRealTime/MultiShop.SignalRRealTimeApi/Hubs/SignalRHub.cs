using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {

        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        public override async Task OnConnectedAsync()
        {

            var accessToken = Context.GetHttpContext().Request.Query["access_token"];
            await base.OnConnectedAsync();
        }
        public async Task SendStatisticAsync(string receiverId)
        {

            var token = Context.GetHttpContext().Request.Query["access_token"];
            var commentCount = await _signalRCommentService.GetCommentCount(token);
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);

            var messageCount = await _signalRMessageService.GetMessageCountByReceiverId(token,receiverId);
            await Clients.All.SendAsync("ReceiveMessageCount", messageCount);
        }
    }
}
