using System;

namespace App.ChatDtos
{
    public class ChatMemberDto
    {
        public string UserName { get; set; }

        public Guid ChatId { get; set; }

        public long UserId { get; set; }
    }
}