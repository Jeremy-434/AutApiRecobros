using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Aliado> Aliados { get; set; }

    public virtual DbSet<Aplicaciones> Aplicaciones { get; set; }

    public virtual DbSet<CentroCosto> CentroCostos { get; set; }

    public virtual DbSet<Consolidado> Consolidados { get; set; }

    public virtual DbSet<ControlArchivo> ControlArchivos { get; set; }

    public virtual DbSet<HistorialConsolidado> HistorialConsolidados { get; set; }

    public virtual DbSet<LogErrores> LogErrores { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=(local);Database=recobrosDB;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aliado>(entity =>
        {
            entity.HasKey(e => e.IdAliado).HasName("PK__Aliados__CA348563DE1FB9E0");
        });

        modelBuilder.Entity<Aplicaciones>(entity =>
        {
            entity.HasKey(e => e.IdAplicacion).HasName("PK__Aplicaci__D3D4F74AC06518AB");

            entity.HasOne(d => d.IdAliadoNavigation).WithMany(p => p.Aplicaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdAliados");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Aplicaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdServicio");
        });

        modelBuilder.Entity<CentroCosto>(entity =>
        {
            entity.HasKey(e => e.IdCentroCosto).HasName("PK__CentroCo__5E1304C010B757A3");
        });

        modelBuilder.Entity<Consolidado>(entity =>
        {
            entity.HasKey(e => e.IdConsolidado).HasName("PK__Consolid__6E667D5AB49D33D9");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.IdAliadoNavigation).WithMany(p => p.Consolidados).HasConstraintName("FKC_IdAliado");

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
            entity.HasKey(e => e.IdControlArchivo).HasName("PK__ControlA__C9A81DCF802F43E6");

            entity.HasOne(d => d.IdAliadoNavigation).WithMany(p => p.ControlArchivos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IdAliado");
        });

        modelBuilder.Entity<HistorialConsolidado>(entity =>
        {
            entity.HasKey(e => e.IdHistorialConsolidado).HasName("PK__Historia__BE406C390A566C34");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<LogErrores>(entity =>
        {
            entity.HasKey(e => e.IdLogError).HasName("PK__LogError__1AAC05E9653EAE7F");

            entity.HasOne(d => d.IdConsolidadoNavigation).WithMany(p => p.LogErrores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKL_IdConsolidado");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDCCAA973CA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
