using System;
using Spells.Domain.Contracts;

namespace Domain.Entities
{
    public class Message : HasId<Guid>
    {
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }

        public string Text { get; set; }
    }
}