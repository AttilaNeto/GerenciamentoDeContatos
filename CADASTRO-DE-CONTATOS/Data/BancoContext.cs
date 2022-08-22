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

    }
}
