using System;
using System.Collections.Generic;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class StoreDB : DbContext
{
    public StoreDB()
    {
    }

    public StoreDB(DbContextOptions<StoreDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<CategoryState> CategoryState { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductState> ProductState { get; set; }

    public virtual DbSet<Purchase> Purchase { get; set; }

    public virtual DbSet<PurchaseProduct> PurchaseProduct { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=StoreDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKCategory");

            entity.HasIndex(e => e.Name, "UXCategoryName").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.CategoryState).WithMany(p => p.Category)
                .HasForeignKey(d => d.CategoryStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCategoryCategoryStateCategoryStateId");
        });

        modelBuilder.Entity<CategoryState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKCategoryState");

            entity.HasIndex(e => e.Name, "UXCategoryStateName").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKProduct");

            entity.HasIndex(e => e.Name, "UXProductName").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Product)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCategoryProductCategoryId");

            entity.HasOne(d => d.ProductState).WithMany(p => p.Product)
                .HasForeignKey(d => d.ProductStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProductStateProductProductStateId");
        });

        modelBuilder.Entity<ProductState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKProductState");

            entity.HasIndex(e => e.Name, "UXProductStateName").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKPurchase");

            entity.Property(e => e.CustomerAddress).HasMaxLength(255);
            entity.Property(e => e.CustomerDocumentId).HasMaxLength(9);
            entity.Property(e => e.CustomerEmail).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerPhone).HasMaxLength(8);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PurchaseProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PKPurchaseProduct");

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseProduct)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKProductPurchaseProductProductId");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseProduct)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPurchasePurchaseProductPurchaseId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
