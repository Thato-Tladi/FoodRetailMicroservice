using Api.Models;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=FoodRetailerConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsumerHistory>(entity =>
        {
            entity.HasKey(e => e.ConsumerHistoryId).HasName("PK__Consumer__E8574D79E87A9ED6");

            entity.ToTable("ConsumerHistory", "FoodRetailMicroserviceSchema");

            entity.Property(e => e.ConsumerHistoryId).HasColumnName("consumer_history_id");
            entity.Property(e => e.ConsumerId).HasColumnName("consumer_id");
            entity.Property(e => e.PurchasedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("purchased_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
