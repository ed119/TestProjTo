using System.Collections.Generic;

namespace App.ChatDtos
{
    public class CreateChatDto
    {
        public string Name { get; set; }

        public List<long> UserIds { get; set; }
    }
}