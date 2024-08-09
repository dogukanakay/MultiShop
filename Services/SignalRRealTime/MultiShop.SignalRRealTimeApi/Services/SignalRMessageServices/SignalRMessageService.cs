namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetMessageCountByReceiverId(string recevierId)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/message/usermessages/GetMessageCountByReceiverId?receiverId=" + recevierId);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
