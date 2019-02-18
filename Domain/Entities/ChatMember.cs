using System;

namespace Domain.Entities
{
    public class ChatMember
    {
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }

        public long UserId { get; set; }
    }
}