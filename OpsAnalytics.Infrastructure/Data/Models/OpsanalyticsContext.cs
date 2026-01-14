using Microsoft.EntityFrameworkCore;

namespace OpsAnalytics.Infrastructure.Data.Models;

public partial class OpsanalyticsContext : DbContext
{
    public OpsanalyticsContext()
    {
    }

    public OpsanalyticsContext(DbContextOptions<OpsanalyticsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RawUpload> RawUploads { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<UploadError> UploadErrors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RawUpload>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FileName).IsRequired();
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Region).IsRequired();
            entity.Property(e => e.Source).IsRequired();
        });

        modelBuilder.Entity<UploadError>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ColumnName).IsRequired();
            entity.Property(e => e.ErrorMessage).IsRequired();
            entity.Property(e => e.UploadId).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
