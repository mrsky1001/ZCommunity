using System.Data.Entity;
using Domain.Models;

namespace Domain.Context
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase() : base("ZCommunityContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
           modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followings)
                .Map(map =>
                {
                    map.MapLeftKey("FollowingId");
                    map.MapRightKey("FollowerId");
                    map.ToTable("Follow");
                });

            modelBuilder.Entity<User>().HasMany(u => u.Messages);
            modelBuilder.Entity<Message>().HasMany(u => u.Images);
            modelBuilder.Entity<Message>().HasMany(u => u.Likes);

            base.OnModelCreating(modelBuilder);
        }
    }
}
