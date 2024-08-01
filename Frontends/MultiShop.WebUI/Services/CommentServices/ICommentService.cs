using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentsAsync();
        Task<HttpResponseMessage> CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<HttpResponseMessage> UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task<HttpResponseMessage> DeleteCommentAsync(int id);
        Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string id);
        Task<UpdateCommentDto> GetByIdCommentToUpdateAsync(int id);
    }
}
