using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SP_MedicalGroup_API.Domains;

#nullable disable

namespace SP_MedicalGroup_API.Contexts
{
    public partial class SPMedicalGroupContext : DbContext
    {
        public SPMedicalGroupContext()
        {
        }

        public SPMedicalGroupContext(DbContextOptions<SPMedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoDeUsuario> TipoDeUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog= Medical_Group; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__52A90951BDC4B8DE");

                entity.ToTable("Clinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeAbertura)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('6AM')");

                entity.Property(e => e.HorarioDeEncerrar)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('23PM')");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D8354AE309");

                entity.Property(e => e.DataConsulta).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                     entity.Property(e => e.Receita)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Exames)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Não')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__IdMedi__3B75D760");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__IdPaci__3A81B327");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__IdSitu__3C69FB99");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__5676CEFF40019AF6");

                entity.ToTable("Especialidade");

                entity.Property(e => e.Especialidades)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__C326E6527E108E0B");

                entity.ToTable("Medico");

                entity.Property(e => e.DataDeNascimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__IdClinic__37A5467C");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__Medico__IdEspeci__36B12243");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__IdUsuari__35BCFE0A");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49BAB58618F");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8A5A05B27")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Paciente__C1F89731FE4FF9F4")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataDeNasc).HasColumnType("date");

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ENDEREÇO");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Paciente__IdUsua__2B3F6F97");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__810BCE3ABA89D9E7");

                entity.ToTable("Situacao");

                entity.Property(e => e.TipoSituacao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDeUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoDeUsuario)
                    .HasName("PK__TipoDeUs__8C8B582A6146FB78");

                entity.ToTable("TipoDeUsuario");

                entity.Property(e => e.TipoDeUsuario1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TipoDeUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9710F57B28");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoDeUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDeUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoD__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
