using System.Net.Http.Headers;

namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService:ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCommentCount(string token)
        {
            // Create HttpClient instance (consider using IHttpClientFactory for better management)
            using var client = new HttpClient();

            // Add token to the Authorization header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Make the request
            var responseMessage = await client.GetAsync("http://localhost:5000/services/comment/comments/GetCommentCount");

            // Ensure successful status code
            responseMessage.EnsureSuccessStatusCode();

            // Read and return the content
            var commentCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return commentCount;
        }

    }
}
