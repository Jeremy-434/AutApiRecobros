using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace AutApiRecobros.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aliados> Aliados { get; set; }

    public virtual DbSet<Aplicaciones> Aplicaciones { get; set; }

    public virtual DbSet<CentroCostos> CentroCostos { get; set; }

    public virtual DbSet<Consolidado> Consolidados { get; set; }

    public virtual DbSet<ControlArchivo> ControlArchivos { get; set; }

    public virtual DbSet<HistorialConsolidado> HistorialConsolidados { get; set; }

    public virtual DbSet<LogErrores> LogErrores { get; set; }

    public virtual DbSet<Parametros> Parametros { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //To protect potentially sensitive information in your connection string, you should move it out of source code.You can avoid scaffolding the connection string by using the Name = syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=22LAP5CG0525JCB;Initial Catalog=recobrosDB;Integrated Security=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aliados>(entity =>
        {
            entity.HasKey(e => e.IdAliado).HasName("PK__Aliados__CA34856324D93F99");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
        });
        modelBuilder.Entity<Aplicaciones>(entity =>
        {
            entity.HasKey(e => e.IdAplicacion).HasName("PK__Aplicaci__D3D4F74ACBDF768E");
            entity.HasOne(d => d.IdAliadoNavigation)
            .WithMany(p => p.Aplicaciones)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdAliados");
            entity.HasOne(d => d.IdServicioNavigation)
            .WithMany(p => p.Aplicaciones)
            .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdServicio");
        });

        modelBuilder.Entity<CentroCostos>(entity =>
        {
            entity.HasKey(e => e.IdCentroCosto).HasName("PK__CentroCo__5E1304C0FA27CFC8");
        });

        modelBuilder.Entity<Consolidado>(entity =>
        {
            entity.HasKey(e => e.IdConsolidado).HasName("PK__Consolid__6E667D5AFC8CA909");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("((1))");
            entity.Property(e => e.Driver).HasDefaultValueSql("('No. de usuarios')");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdAliadoNavigation).WithMany(p => p.Consolidados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKC_IdAliado");

            entity.HasOne(d => d.IdAplicacionNavigation).WithMany(p => p.Consolidados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKC_IdAplicacion");

            entity.HasOne(d => d.IdControlArchivoNavigation).WithMany(p => p.Consolidados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKC_IdControlArchivo");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Consolidados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKC_IdServicio");
        });

        modelBuilder.Entity<ControlArchivo>(entity =>
        {
            entity.HasKey(e => e.IdControlArchivo).HasName("PK__ControlA__C9A81DCF38D2E1A6");

            entity.HasOne(d => d.IdAliadoNavigation).WithMany(p => p.ControlArchivos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdAliado");
        });

        modelBuilder.Entity<HistorialConsolidado>(entity =>
        {
            entity.HasKey(e => e.IdHistorialConsolidado).HasName("PK__Historia__BE406C39FBE722AF");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("((1))");
            entity.Property(e => e.Driver).HasDefaultValueSql("('No. de usuarios')");
            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<LogErrores>(entity =>
        {
            entity.HasKey(e => e.IdLogError).HasName("PK__LogError__1AAC05E99F69F3AE");
        });

        modelBuilder.Entity<Parametros>(entity =>
        {
            entity.HasKey(e => e.IdParametro).HasName("PK__Parametr__3D24E3253B867A1E");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDC140ABD66");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
