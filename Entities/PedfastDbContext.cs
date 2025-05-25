using Microsoft.EntityFrameworkCore;

namespace Pedfast.Entities;

public partial class PedfastDbContext : DbContext
{
    public PedfastDbContext()
    {
    }

    public PedfastDbContext(DbContextOptions<PedfastDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PagamentoStatus> PagamentoStatuses { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidosBackup> PedidosBackups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<PagamentoStatus>(entity =>
        {
            entity.HasKey(e => e.IdS).HasName("PRIMARY");

            entity.ToTable("pagamento_status");

            entity.HasIndex(e => e.StatuComp, "statu_comp").IsUnique();

            entity.HasIndex(e => e.Status, "status").IsUnique();

            entity.Property(e => e.IdS).HasColumnName("id_s");
            entity.Property(e => e.StatuComp)
                .HasMaxLength(100)
                .HasColumnName("statu_comp");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedidos");

            entity.HasIndex(e => e.StatusComp, "status_comp");

            entity.HasIndex(e => e.StatusSg, "status_sg");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .HasColumnName("cliente");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.StatusComp)
                .HasMaxLength(100)
                .HasColumnName("status_comp");
            entity.Property(e => e.StatusSg)
                .HasMaxLength(1)
                .HasColumnName("status_sg");

            entity.HasOne(d => d.StatusCompNavigation).WithMany(p => p.PedidoStatusCompNavigations)
                .HasPrincipalKey(p => p.StatuComp)
                .HasForeignKey(d => d.StatusComp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_ibfk_2");

            entity.HasOne(d => d.StatusSgNavigation).WithMany(p => p.PedidoStatusSgNavigations)
                .HasPrincipalKey(p => p.Status)
                .HasForeignKey(d => d.StatusSg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_ibfk_1");
        });

        modelBuilder.Entity<PedidosBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedidos_backup");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .HasColumnName("cliente");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.StatusComp)
                .HasMaxLength(100)
                .HasColumnName("status_comp");
            entity.Property(e => e.StatusSg)
                .HasMaxLength(1)
                .HasColumnName("status_sg");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
