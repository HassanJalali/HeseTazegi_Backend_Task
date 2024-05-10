using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HeseTazegi.Read.Context.Models;

public partial class HeseTazegiReadContext : DbContext
{
    public HeseTazegiReadContext()
    {
    }

    public HeseTazegiReadContext(DbContextOptions<HeseTazegiReadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodIngredient> FoodIngredients { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("Foods", "HeseTazegi");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<FoodIngredient>(entity =>
        {
            entity.HasKey(e => new { e.FoodId, e.Id });

            entity.ToTable("FoodIngredient", "HeseTazegi");

            entity.HasIndex(e => e.IngredientId, "IX_FoodIngredient_IngredientId");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Food).WithMany(p => p.FoodIngredients).HasForeignKey(d => d.FoodId);

            entity.HasOne(d => d.Ingredient).WithMany(p => p.FoodIngredients).HasForeignKey(d => d.IngredientId);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredients", "HeseTazegi");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
