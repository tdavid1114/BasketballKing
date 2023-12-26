using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BK_Server.Models
{
    public partial class BasketballkingContext : DbContext
    {
        public BasketballkingContext()
        {
        }

        public BasketballkingContext(DbContextOptions<BasketballkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Infrastructure> Infrastructures { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Stadium> Stadia { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Upgrade> Upgrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Infrastructure>(entity =>
            {
                entity.ToTable("infrastructure");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coaches).HasColumnName("coaches");

                entity.Property(e => e.Gym).HasColumnName("gym");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Infrastructure)
                    .HasForeignKey<Infrastructure>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teamid3");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("players");

                entity.HasIndex(e => e.Teamid, "teamid_idx");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Blocking).HasColumnName("blocking");

                entity.Property(e => e.Defence).HasColumnName("defence");

                entity.Property(e => e.Energy).HasColumnName("energy");

                entity.Property(e => e.Finishing).HasColumnName("finishing");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.IsInjured).HasColumnName("isInjured");

                entity.Property(e => e.IsStarter).HasColumnName("isStarter");

                entity.Property(e => e.Marketvalue).HasColumnName("marketvalue");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .HasColumnName("name");

                entity.Property(e => e.Overall).HasColumnName("overall");

                entity.Property(e => e.Playmaking).HasColumnName("playmaking");

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .HasColumnName("position");

                entity.Property(e => e.Rebounding).HasColumnName("rebounding");

                entity.Property(e => e.Retiringage).HasColumnName("retiringage");

                entity.Property(e => e.Shooting).HasColumnName("shooting");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.Strength).HasColumnName("strength");

                entity.Property(e => e.Teamid).HasColumnName("teamid");

                entity.Property(e => e.Wage).HasColumnName("wage");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.Teamid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teamid");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.ToTable("stadium");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity)
                    .HasColumnType("mediumint")
                    .HasColumnName("capacity")
                    .HasDefaultValueSql("'100'");

                entity.Property(e => e.Ticketprice)
                    .HasColumnName("ticketprice")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Stadium)
                    .HasForeignKey<Stadium>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("teamid2");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");

                entity.Property(e => e.Teamid).HasColumnName("teamid");

                entity.Property(e => e.Expense).HasColumnName("expense");

                entity.Property(e => e.Income).HasColumnName("income");

                entity.Property(e => e.Losses).HasColumnName("losses");

                entity.Property(e => e.MatchesPlayed).HasColumnName("matchesPlayed");

                entity.Property(e => e.Money).HasColumnName("money");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.PointDifference).HasColumnName("pointDifference");

                entity.Property(e => e.PointsConceded).HasColumnName("pointsConceded");

                entity.Property(e => e.PointsScored).HasColumnName("pointsScored");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.WinningPercentage).HasColumnName("winningPercentage");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            modelBuilder.Entity<Upgrade>(entity =>
            {
                entity.ToTable("upgrades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .HasMaxLength(30)
                    .HasColumnName("attribute");

                entity.Property(e => e.Expired).HasColumnName("expired");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Playerid).HasColumnName("playerid");

                entity.Property(e => e.Teamid).HasColumnName("teamid");
            });
        }
    }
}