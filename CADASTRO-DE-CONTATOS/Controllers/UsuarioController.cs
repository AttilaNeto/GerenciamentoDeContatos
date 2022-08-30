using CADASTRO_DE_CONTATOS.Data;
using CADASTRO_DE_CONTATOS.Models;
using CADASTRO_DE_CONTATOS.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CADASTRO_DE_CONTATOS.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly BancoContext _context;
        public UsuarioController(IUsuarioRepositorio contatoRepositorio, BancoContext context)
        {
            _usuarioRepositorio = contatoRepositorio;
            _context = context;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();

            return View(usuario);
        }

        public IActionResult CriarModal()
        {

            return PartialView("_CriarModalUsuario");
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return NotFound();
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
