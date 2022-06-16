using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace share_login_api.Models
{
    public partial class UserDBreactContext : DbContext
    {
        public UserDBreactContext()
        {
        }

        public UserDBreactContext(DbContextOptions<UserDBreactContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chatroom> Chatroom { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserDBreact;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chatroom>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.User_1).HasColumnName("User_1");

                entity.Property(e => e.User_2).HasColumnName("User_2");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChatroomId).HasColumnName("Chatroom_Id");

                entity.Property(e => e.Content).HasMaxLength(50);

                entity.Property(e => e.PostTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Answer2).HasMaxLength(50);

                entity.Property(e => e.Answer3).HasMaxLength(50);

                entity.Property(e => e.Answer4).HasMaxLength(50);

                entity.Property(e => e.CorrectAnswer).HasMaxLength(50);

                entity.Property(e => e.ImageName).HasMaxLength(100);

                entity.Property(e => e.Quesion).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
