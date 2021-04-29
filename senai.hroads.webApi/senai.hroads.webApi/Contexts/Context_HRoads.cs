using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class Context_HRoads : DbContext
    {
        public Context_HRoads()
        {
        }

        public Context_HRoads(DbContextOptions<Context_HRoads> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoDeHabilidade> TipoDeHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source= LAPTOP-L0JSQP3E; initial catalog= SENAI_HROADS_TARDE; user Id= sa; pwd= 20nov2004");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classes__0652AF7957C1C1C4");

                entity.Property(e => e.Classe)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Classes__IdHabil__29572725");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30D4F4E10F0");

                entity.Property(e => e.Habilidade1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Habilidade");

                entity.HasOne(d => d.IdTipoDeHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoDeHabilidade)
                    .HasConstraintName("FK__Habilidad__IdTip__267ABA7A");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__4C5EDFB3E388DA84");

                entity.ToTable("Personagem");

                entity.Property(e => e.DataAtualização).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__IdCla__2C3393D0");
            });

            modelBuilder.Entity<TipoDeHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeHabilidade)
                    .HasName("PK__TipoDeHa__95361A7991391F6C");

                entity.ToTable("TipoDeHabilidade");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BD6BB1223");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97E72D49EE");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534FF342B0D")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__31EC6D26");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
