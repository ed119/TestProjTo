using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.ChatDtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.ChatServices
{
    public class ChatService
    {
        private readonly DbContext _context;
//        private readonly AuthClaimsProvider _accessor;

        public ChatService(DbContext context)
        {
            _context = context;
        }

        public async Task<List<ChatDto>> Rooms()
        {
            
//            var root = _accessor.Root ?? throw new ArgumentNullException("_accessor.Root");
            
           return await _context.Set<Chat>()
                    .ProjectTo<ChatDto>()
                    .ToListAsync()
                ;

//            var rooms = await _context.Set<Chat>()
//                .Where(x => x.ChatMembers.Any(y => y.UserId == root))
//                .ToListAsync()
//                ;
//
//            return Mapper.Map<List<ChatDto>>(rooms);;
        }

        public async Task<List<MessageDto>> Messages(Guid chatId) => 
            await _context.Set<Message>().Where(x => x.ChatId == chatId).ProjectTo<MessageDto>().ToListAsync();


        public async Task<Guid> CreateChat(CreateChatDto payload)
        {
            var chat = new Chat
            {
                Name = payload.Name
            };
            
            var cm = new List<ChatMember>();
            
            foreach (var userId in payload.UserIds)
            {
                cm.Add(new ChatMember
                {
                    UserId = userId,
                    Chat = chat
                });
            }

            await _context.AddAsync(chat);
            await _context.AddRangeAsync(cm);
            await _context.SaveChangesAsync();

            return chat.Id;
        }
    }
}