using System;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
	public class DataContext : IdentityDbContext<User,AppRole,int,
		IdentityUserClaim<int>,UserRole,
		IdentityUserLogin<int>,
		IdentityRoleClaim<int>,
		IdentityUserToken<int>>
	{
		public DataContext(DbContextOptions options):base(options)
		{
		}

		//public DbSet<User> Users { get; set; }
		public DbSet<UserLike> Likes { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Connection> Connections { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasMany(i => i.UserRoles)
				.WithOne(u => u.User)
				.HasForeignKey(i => i.UserId)
				.IsRequired();

			modelBuilder.Entity<AppRole>()
				.HasMany(i => i.UserRoles)
				.WithOne(i => i.Role)
				.HasForeignKey(i => i.RoleId)
				.IsRequired();


			modelBuilder.Entity<UserLike>()
				.HasKey(k => new { k.SourceUserId, k.TargetUserId });

			modelBuilder.Entity<UserLike>()
				.HasOne(s => s.SourceUser)
				.WithMany(l => l.LikedUsers)
				.HasForeignKey(s => s.SourceUserId)
				.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Message>()
				.HasOne(u => u.Recipient)
				.WithMany(m => m.MessagesReceived)
				.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

