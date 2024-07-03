using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class FoodRetailContext : DbContext
{
    public FoodRetailContext()
    {
    }

    public FoodRetailContext(DbContextOptions<FoodRetailContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConsumerHistory> ConsumerHistories { get; set; }

    public virtual DbSet<FinancialInfo> FinancialInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Database:ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsumerHistory>(entity =>
        {
            entity.HasKey(e => e.ConsumerHistoryId).HasName("PK__Consumer__E8574D79E87A9ED6");

            entity.ToTable("ConsumerHistory", "FoodRetailMicroserviceSchema");

            entity.Property(e => e.ConsumerHistoryId).HasColumnName("consumer_history_id");
            entity.Property(e => e.ConsumerId).HasColumnName("consumer_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PurchasedDate).HasColumnName("purchased_date");
        });

        modelBuilder.Entity<FinancialInfo>(entity =>
        {
            entity.HasKey(e => e.FinancialInfoId).HasName("PK__Financia__6315E63467C06626");

            entity.ToTable("FinancialInfo", "FoodRetailMicroserviceSchema");

            entity.Property(e => e.FinancialInfoId).HasColumnName("financial_info_id");
            entity.Property(e => e.PropertyName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("property_name");
            entity.Property(e => e.PropertyValue).HasColumnName("property_value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
