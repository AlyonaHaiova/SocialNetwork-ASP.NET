using Microsoft.EntityFrameworkCore;
using SocialNetwork.Entities;

namespace SocialNetwork.Context
{

    public class SocialNetworkContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RelationshipEntity> Relationships { get; set; }

        public DbSet<MessageEntity> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=social_network;Username=postgres;Password=postgres");
        }

        public SocialNetworkContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RelationshipEntity>()
                .Property(r => r.User1Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<RelationshipEntity>()
                .Property(r => r.User2Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<RelationshipEntity>()
              .HasOne<UserEntity>(r => r.User1)
              .WithMany()
              .HasForeignKey(r => r.User1Id)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RelationshipEntity>()
             .HasOne<UserEntity>(r => r.User2)
             .WithMany()
             .HasForeignKey(r => r.User2Id)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MessageEntity>()
             .HasOne<UserEntity>(m => m.Sender)
             .WithMany()
             .HasForeignKey(m => m.SenderId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MessageEntity>()
             .HasOne<UserEntity>(m => m.Receiver)
             .WithMany()
             .HasForeignKey(m => m.ReceiverId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}