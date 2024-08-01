using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
            return responseMessage;
        }

        public async Task<HttpResponseMessage> DeleteCommentAsync(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync("comments?id=" + id);
            return responseMessage;
        }



        public async Task<List<ResultCommentDto>> GetAllCommentsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

      

        public async Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetCommentByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentToUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values;
        }

        public async Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
            return responseMessage;
        }
    }
}
