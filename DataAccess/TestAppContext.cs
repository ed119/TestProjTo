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

        }
    }
}