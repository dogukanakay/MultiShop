using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Context;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {

            await _messageContext.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDto));
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            await _messageContext.SaveChangesAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            await _messageContext.SaveChangesAsync();
            return _mapper.Map<GetByIdMessageDto>(values);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string recevierId)
        {
            var values = await _messageContext.UserMessages.Where(m => m.RecevierId == recevierId).ToListAsync();
            await _messageContext.SaveChangesAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<int> GetMessageCountAsync()
        {
            var count = await _messageContext.UserMessages.CountAsync();
            return count;
        }

        public async Task<int> GetMessageCountByReceiverId(string receiverId)
        {
            var values = await _messageContext.UserMessages.Where(m => m.RecevierId.Equals(receiverId)).CountAsync();
            return values;

        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string senderId)
        {
            var values = await _messageContext.UserMessages.Where(m => m.SenderId == senderId).ToListAsync();
            await _messageContext.SaveChangesAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            _messageContext.UserMessages.Update(_mapper.Map<UserMessage>(updateMessageDto));
            await _messageContext.SaveChangesAsync();
        }
    }
}
