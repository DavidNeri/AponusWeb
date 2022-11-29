using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Models;

public partial class AponusContext : DbContext
{
    public AponusContext()
    {
    }

    public AponusContext(DbContextOptions<AponusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-07VBCCN; Database=Aponus;User Id=Administrador;Password=AponusIng;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AI");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_PRODUCTS_1");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AI")
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AI")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Price)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.ProductDescriptionDn).HasColumnName("PRODUCT_DESCRIPTION_DN");
            entity.Property(e => e.ProductDescriptionInsideDiameter).HasColumnName("PRODUCT_DESCRIPTION_INSIDE_DIAMETER");
            entity.Property(e => e.ProductDescriptionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AI")
                .HasColumnName("PRODUCT_DESCRIPTION_NAME");
            entity.Property(e => e.ProductDescriptionOutsideDiameter).HasColumnName("PRODUCT_DESCRIPTION_OUTSIDE_DIAMETER");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("((0))")
                .HasColumnName("QUANTITY");

            /*entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTS_PRODUCT_CATEGORIES");*/
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Table_1");

            entity.ToTable("PRODUCT_CATEGORIES");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AI")
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AI")
                .HasColumnName("CATEGORY_DESCRIPTION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
