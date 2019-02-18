using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TestAppContext : DbContext
    {
        public TestAppContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatMember> ChatMember { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<ChatMember>()
                .HasKey(x => new {x.ChatId, x.UserId});

            builder.Entity<Chat>()
                .Property(x => x.Name).IsRequired();
            
            builder.Entity<Chat>()
                .HasMany(c => c.ChatMembers)
                .WithOne(c => c.Chat)
                .IsRequired();

            builder.Entity<ChatMember>()
                .HasOne(m => m.Chat)
                .WithMany(m => m.ChatMembers);

            builder.Entity<Chat>().HasData(new Chat
            {
                Id = new Guid("97959327-435E-4762-8995-1367583222E6"),
                Name = "SuperName",
            });

            builder.Entity<ChatMember>().HasData(new List<ChatMember>()
            {
                new ChatMember()
                {
                    ChatId = new Guid("97959327-435E-4762-8995-1367583222E6"),
                    UserId = 1
                },
                new ChatMember()
                {
                    ChatId = new Guid("97959327-435E-4762-8995-1367583222E6"),
                    UserId = 2
                },
                new ChatMember()
                {
                    ChatId = new Guid("97959327-435E-4762-8995-1367583222E6"),
                    UserId = 3
                }
            });

        }
    }
}