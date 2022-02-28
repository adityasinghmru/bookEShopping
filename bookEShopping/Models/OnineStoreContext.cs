using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bookEShopping.Models
{
    public partial class OnineStoreContext : DbContext
    {
        public OnineStoreContext()
        {
        }

        public OnineStoreContext(DbContextOptions<OnineStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBook> TblBooks { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("Server=LAPTOP-TQMHD08K\\SQLEXPRESS; Database=OnineStore; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBook>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__tbl_book__490D1AE1E2DD8D7D");

                entity.ToTable("tbl_book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookAuthor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("book_author");

                entity.Property(e => e.BookCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("book_category");

                entity.Property(e => e.BookImage)
                    .IsUnicode(false)
                    .HasColumnName("book_image");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("book_name");

                entity.Property(e => e.BookPrice).HasColumnName("book_price");

                entity.Property(e => e.BookQuantity).HasColumnName("book_quantity");

                entity.Property(e => e.BookSatuts).HasColumnName("book_satuts");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tbl_orde__4659622932445C4E");

                entity.ToTable("tbl_order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__tbl_order__book___3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tbl_order__user___3F466844");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_user__B9BE370F144B5C9C");

                entity.ToTable("tbl_user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserCategory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("user_category");

                entity.Property(e => e.UserContact)
                    .HasMaxLength(10)
                    .HasColumnName("user_contact");

                entity.Property(e => e.UserDob)
                    .HasColumnType("date")
                    .HasColumnName("user_dob");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserGender)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_gender");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(15)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
