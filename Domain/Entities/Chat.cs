using System;
using System.Collections.Generic;
using Spells.Domain.Contracts;

namespace Domain.Entities
{
    public class Chat : HasId<Guid>
    {
        public string Name { get; set; }
        
        public ICollection<ChatMember> ChatMembers { get; } = new List<ChatMember>();
    }
}