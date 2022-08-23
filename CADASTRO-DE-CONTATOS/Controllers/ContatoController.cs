using CADASTRO_DE_CONTATOS.Models;
using CADASTRO_DE_CONTATOS.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CADASTRO_DE_CONTATOS.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult CriarModal()
        {
            return PartialView("CriarModal");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(Index);
            }
            catch (Exception erro)
            {
                TempData["MensagemError"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult EditarModal(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return PartialView("EditarModal", contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, não conseguimos alterar seu contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarModal(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return PartialView("ApagarModal", contato);
        }

        public IActionResult Deletar(int id)
        {

            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = $"Ops, não conseguimos apagar seu contato.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemError"] = $"Ops, não conseguimos apagar seu contato. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
