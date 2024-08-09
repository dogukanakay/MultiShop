namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public class SignalRCommentService:ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/comment/comments/GetCommentCount");
            var commentCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return commentCount;
        }

    }
}
