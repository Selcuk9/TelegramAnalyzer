using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TelegramAnalyzer.DataBase.Models;

namespace TelegramAnalyzer.DataBase.Context
{
    public partial class TelegramStatisticsContext : DbContext
    {
        public TelegramStatisticsContext(DbContextOptions<TelegramStatisticsContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public  DbSet<StatisticsChannels> StatisticsChannels { get; set; }
        public  DbSet<StatisticsPosts> StatisticsPosts { get; set; }
        public  DbSet<TelegramChannels> TelegramChannels { get; set; }
        public  DbSet<TelegramPosts> TelegramPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatisticsChannels>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TelegramId).HasDefaultValueSql("(CONVERT([bigint],(0)))");
            });

            modelBuilder.Entity<StatisticsPosts>(entity =>
            {
                entity.Property(e => e.ChannelTelegramId).HasDefaultValueSql("(CONVERT([bigint],(0)))");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TelegramChannels>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TelegramPosts>(entity =>
            {
                entity.Property(e => e.ChannelTelegramId).HasDefaultValueSql("(CONVERT([bigint],(0)))");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TelegramId).HasDefaultValueSql("(CONVERT([bigint],(0)))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
