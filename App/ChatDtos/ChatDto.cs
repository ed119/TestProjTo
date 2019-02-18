using System;

namespace App.ChatDtos
{
    public class ChatDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ChatMemberDto[] ChatMembers { get; set; }
    }
}