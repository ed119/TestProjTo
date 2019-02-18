using App.ChatDtos;
using AutoMapper;
using Domain.Entities;

namespace App.ChatServices
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Chat, ChatDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));

            CreateMap<ChatMember, ChatMemberDto>()
                .ForMember(x => x.UserName, 
                    y => y.Ignore());

            CreateMap<Message, MessageDto>();
        }
    }
}