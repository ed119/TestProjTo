using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.ChatDtos;
using App.ChatServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestProjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }
        
        [HttpPost("Room")]
        public async Task<List<ChatDto>> Room() => 
            await _chatService.Rooms();

        [HttpPost("Message")]
        public async Task<List<MessageDto>> Message([FromBody]Guid chatId) =>
            await _chatService.Messages(chatId);

        [HttpPost("Create")]
        public async Task<Guid> Create([FromBody] CreateChatDto payload) =>
            await _chatService.CreateChat(payload);
    }
}