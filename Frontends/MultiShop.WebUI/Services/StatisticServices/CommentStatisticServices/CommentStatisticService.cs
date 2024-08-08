
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetActiveCommentCount");
            var activeCommentCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return activeCommentCount;
        }

        public async Task<int> GetCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetCommentCount");
            var commentCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return commentCount;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            var passiveCommentCount = await responseMessage.Content.ReadFromJsonAsync<int>();
            return passiveCommentCount;
        }
    }
}
