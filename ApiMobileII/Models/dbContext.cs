using Microsoft.EntityFrameworkCore;

namespace ApiMobileII.Models
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carro> Carros { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Revisao> Revisaos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=ApiMobile;Persist Security Info=True;User ID=sa;Password=guta1299!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Carros)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK_dbo.Carro_dbo.Marca_marca_id1");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_dbo.Endereco_dbo.Usuario_Usuario_id");
            });

            modelBuilder.Entity<Revisao>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("('Agendada')");

                entity.HasOne(d => d.Carro)
                    .WithMany(p => p.Revisaos)
                    .HasForeignKey(d => d.CarroId)
                    .HasConstraintName("FK_dbo.Revisao_dbo.Carro_carro_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Revisaos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_dbo.Revisao_dbo.Usuario_usuario_id1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
