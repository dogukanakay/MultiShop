using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string recevierId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
    }
}
