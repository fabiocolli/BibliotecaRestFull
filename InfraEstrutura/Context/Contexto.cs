using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Context
{
    public class Contexto : DbContext
    {
		public Contexto(DbContextOptions<Contexto> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseSqlServer(PegarStringConexao());

				base.OnConfiguring(optionsBuilder);
			}
		}
		public string PegarStringConexao()
		{
			return "Data Source=fc-p\\local;Initial Catalog=BibliotecaRestFull;" +
				"Persist Security Info=True;User " +
				"ID=sa;Password=qM1t$up|iC74;TrustServerCertificate=True";
		}

		public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Exemplar> Exemplares { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Emprestimos)
                .WithOne(e => e.Pessoa)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Emprestimo>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Emprestimo>()
                .HasMany(e => e.Exemplares)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Titulo>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Titulo>()
                .HasMany(t => t.Autores)
                .WithMany(a => a.Titulos);

            modelBuilder.Entity<Exemplar>()
                .HasKey(ex => ex.Id);

            modelBuilder.Entity<Exemplar>()
                .HasOne(ex => ex.Titulo)
                .WithMany()
                .HasForeignKey(ex => ex.TituloId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Autor>()
                .HasKey(a => a.Id);
        }
    }
}
