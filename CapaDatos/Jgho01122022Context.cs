using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos;

public partial class Jgho01122022Context : DbContext
{
    public Jgho01122022Context()
    {
    }

    public Jgho01122022Context(DbContextOptions<Jgho01122022Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AlumnosMateria> AlumnosMaterias { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-G3PBMH36; Database= JGHO_01122022; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumno__460B47404864D5EA");

            entity.ToTable("Alumno");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AlumnosMateria>(entity =>
        {
            entity.HasKey(e => e.IdAlumnoMateria).HasName("PK__AlumnosM__E13EDA37A326F036");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnosMateria)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__AlumnosMa__IdAlu__145C0A3F");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.AlumnosMateria)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__AlumnosMa__IdMat__15502E78");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__EC17467032616154");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
