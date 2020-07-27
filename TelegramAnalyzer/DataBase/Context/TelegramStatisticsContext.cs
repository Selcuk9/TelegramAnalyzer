using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TelegramAnalyzer.DataBase.Models;

namespace TelegramAnalyzer.DataBase.Context
{
    public partial class TelegramStatisticsContext : DbContext
    {
        public TelegramStatisticsContext()
        {
        }

        public TelegramStatisticsContext(DbContextOptions<TelegramStatisticsContext> options)
            : base(options)
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<StatisticsChannel> StatisticsChannel { get; set; }
        public virtual DbSet<StatisticsPosts> StatisticsPosts { get; set; }
        public virtual DbSet<TelegramChannels> TelegramChannels { get; set; }
        public virtual DbSet<TelegramPosts> TelegramPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatisticsChannel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<StatisticsPosts>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.StatisticsPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_StatisticsPosts_TelegramPosts");
            });

            modelBuilder.Entity<TelegramChannels>(entity =>
            {
                entity.HasKey(e => e.TelegramId)
                    .HasName("PK_TelegramChannels_1");

                entity.Property(e => e.TelegramId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<TelegramPosts>(entity =>
            {
                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.TelegramPosts)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TelegramPosts_TelegramChannels");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
