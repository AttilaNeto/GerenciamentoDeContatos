using CADASTRO_DE_CONTATOS.Models;

namespace CADASTRO_DE_CONTATOS.Repositorio.Interface
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);

    }
}
