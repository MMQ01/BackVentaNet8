using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackVentas.Modelos;

public partial class VentasContext : DbContext
{
    public VentasContext()
    {
    }

    public VentasContext(DbContextOptions<VentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductosPedido> ProductosPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\MMQ01;Initial Catalog=Ventas;User ID=sa;Password=2001;Integrated Security=False;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0757234A6E");

            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC07EF78D2CF");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Identificacion, "IX_Cliente").IsUnique();

            entity.HasIndex(e => e.IdCategoria, "IdCategoria_idx");

            entity.Property(e => e.Contraseña).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(2);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Categorias");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3214EC077E44AA98");

            entity.HasIndex(e => e.IdCliente, "FK_Pedidos_cliente_idx");

            entity.Property(e => e.Estado).HasMaxLength(2);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedidos__IdClien__3E52440B");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07394EC974");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(2);
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ProductosPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0736BBEA4F");

            entity.ToTable("Productos_Pedidos");

            entity.HasIndex(e => e.IdPedido, "FK_Pedido_idx");

            entity.HasIndex(e => e.IdProducto, "FK_Producto_idx");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ProductosPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Productos__IdPed__412EB0B6");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductosPedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__IdPro__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
