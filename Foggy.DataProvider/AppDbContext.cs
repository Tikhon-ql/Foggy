using Foggy.DataProvider.Models;
using Foggy.DataProvider.Models.Identity;
using Foggy.DataProvider.Models.SocialNetworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRefreshToken> RefreshTokens { get; set; }
        public DbSet<ToRemember> ToRemembers { get; set; }
        public DbSet<SocialNetwork> SocialNetworkToNotifies { get; set; }
        public DbSet<TelegramSN> TelegramSNs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserRefreshToken>().HasOne(r => r.User).WithOne(u=>u.RefreshToken).HasForeignKey<UserRefreshToken>(r=>r.UserId);
            //modelBuilder.Entity<User>().HasMany(u=>u.ToRemembers).WithOne();
            modelBuilder.Entity<SocialNetwork>()
               .HasDiscriminator<string>("sn_type")
               .HasValue<SocialNetwork>("sn_base")
               .HasValue<TelegramSN>("sn_telegram");
            base.OnModelCreating(modelBuilder);
        }
    }
}
