using System.Net.Http.Headers;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetMessageCountByReceiverId(string token, string recevierId)
        {
            // Create HttpClient instance (consider using IHttpClientFactory for better management)
            using var client = new HttpClient();

            // Add token to the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Make the request
            var responseMessage = await client.GetAsync("http://localhost:5000/services/message/usermessages/GetMessageCountByReceiverId?receiverId=" + recevierId);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
