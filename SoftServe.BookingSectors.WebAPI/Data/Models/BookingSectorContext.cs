﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoftServe.BookingSectors.WebAPI.Data.Helpers;

namespace SoftServe.BookingSectors.WebAPI.Data.Models
{
    public partial class BookingSectorContext : DbContext
    {
        public BookingSectorContext()
        {
        }

        public BookingSectorContext(DbContextOptions<BookingSectorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingSector> BookingSector { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentSector> TournamentSector { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(@ConfigurationHelper.GetDatabaseConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSector>(entity =>
            {
                entity.ToTable("BOOKING_SECTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingEnd)
                    .HasColumnName("BOOKING_END")
                    .HasColumnType("date");

                entity.Property(e => e.BookingStart)
                    .HasColumnName("BOOKING_START")
                    .HasColumnType("date");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.IsApproved).HasColumnName("IS_APPROVED");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.SectorId).HasColumnName("SECTOR_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.BookingSector)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SECTOR_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookingSector)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ID");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("LANGUAGE");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_LANGUAGE_NAME")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("SECTOR");

                entity.HasIndex(e => e.Number)
                    .HasName("UK_NUMBER")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.GpsLat)
                    .HasColumnName("GPS_LAT")
                    .HasColumnType("numeric(8, 6)");

                entity.Property(e => e.GpsLng)
                    .HasColumnName("GPS_LNG")
                    .HasColumnType("numeric(8, 6)");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Number).HasColumnName("NUMBER");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("SETTING");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_NAME")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.MaxBookingDays).HasColumnName("MAX_BOOKING_DAYS");

                entity.Property(e => e.MaxBookingSectors).HasColumnName("MAX_BOOKING_SECTORS");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("TOURNAMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("DATE_END")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("DATE_START")
                    .HasColumnType("date");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PreparationTerm).HasColumnName("PREPARATION_TERM");
            });

            modelBuilder.Entity<TournamentSector>(entity =>
            {
                entity.ToTable("TOURNAMENT_SECTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.IdSectors).HasColumnName("ID_SECTORS");

                entity.Property(e => e.IdTournament).HasColumnName("ID_TOURNAMENT");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.HasOne(d => d.IdSectorsNavigation)
                    .WithMany(p => p.TournamentSector)
                    .HasForeignKey(d => d.IdSectors)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_SECTORS");

                entity.HasOne(d => d.IdTournamentNavigation)
                    .WithMany(p => p.TournamentSector)
                    .HasForeignKey(d => d.IdTournament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_TOURNAMENT");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.HasIndex(e => e.Phone)
                    .HasName("UK_PHONE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LANGUAGE_ID");

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LANGUAGE_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ROLE_ID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("USER_ROLE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUserId).HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.ModDate)
                    .HasColumnName("MOD_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModUserId).HasColumnName("MOD_USER_ID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("ROLE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
