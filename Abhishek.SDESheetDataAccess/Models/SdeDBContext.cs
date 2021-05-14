using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Abhishek.SDESheetDataAccess.Models
{
    public partial class SdeDBContext : DbContext
    {
        public SdeDBContext()
        {
        }

        public SdeDBContext(DbContextOptions<SdeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Progress> Progress { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("SdeDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Progress>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateOfCompletion)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Progress_EmailId");

                entity.HasOne(d => d.Ques)
                    .WithMany(p => p.Progress)
                    .HasForeignKey(d => d.QuesId)
                    .HasConstraintName("fk_Progress_QuesId");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuesId)
                    .HasName("pk_QuesId");

                entity.Property(e => e.QuesLink)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(2048)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("pk_EmailId");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
