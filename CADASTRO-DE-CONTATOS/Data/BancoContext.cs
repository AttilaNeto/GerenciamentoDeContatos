using CADASTRO_DE_CONTATOS.Data.Map;
using CADASTRO_DE_CONTATOS.Models;
using Microsoft.EntityFrameworkCore;


namespace CADASTRO_DE_CONTATOS.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
