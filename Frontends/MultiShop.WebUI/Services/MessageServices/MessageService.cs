using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string recevierId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/GetMessageInbox?id="+recevierId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();    
            return values;
        }

        public async Task<int> GetMessageCountByReceiverId(string recevierId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/GetMessageCountByReceiverId?receiverId=" + recevierId);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId)
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/GetMessageSendbox?id=" + senderId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }
    }
}
