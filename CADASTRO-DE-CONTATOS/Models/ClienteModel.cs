namespace CADASTRO_DE_CONTATOS.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ContatoModel> Contatos { get; set; }
    }
}
