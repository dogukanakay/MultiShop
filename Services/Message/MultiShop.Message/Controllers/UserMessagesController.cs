﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendboxAsync(string id)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInboxAsync(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }
        [HttpPost]

        public async Task<IActionResult> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj başarıyla güncellendi");
        }

        [HttpGet("GetMessageCount")]
        public async Task<IActionResult> GetMessageCountAsync()
        {
            return Ok(await _userMessageService.GetMessageCountAsync());
        }

        [HttpGet("GetMessageCountByReceiverId")]
        public async Task<IActionResult> GetMessageCountByReceiverId(string receiverId) 
        {
            return Ok(await _userMessageService.GetMessageCountByReceiverId(receiverId));
        }
    }
}
