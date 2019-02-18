using System;

namespace App.ChatDtos
{
    public class MessageDto
    {
        public string Text { get; set; }

        public Guid ChatId { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }
        
    }
}