using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string recevierId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
    }
}
