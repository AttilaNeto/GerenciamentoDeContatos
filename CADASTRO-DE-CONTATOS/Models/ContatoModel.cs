using System.ComponentModel.DataAnnotations;

namespace CADASTRO_DE_CONTATOS.Models
{
    public class ContatoModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o numero do contato")]
        public string Numero { get; set; }
    }
}
