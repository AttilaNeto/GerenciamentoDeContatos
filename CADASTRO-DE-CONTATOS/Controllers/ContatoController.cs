using CADASTRO_DE_CONTATOS.Data;
using CADASTRO_DE_CONTATOS.Models;
using CADASTRO_DE_CONTATOS.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CADASTRO_DE_CONTATOS.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly BancoContext _context;
        public ContatoController(IContatoRepositorio contatoRepositorio, BancoContext context)
        {
            _contatoRepositorio = contatoRepositorio;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dB_AttilaContext = _context.Contatos.Include(c => c.Cliente);
            
            return _context.Contatos != null ? 
                        View(await dB_AttilaContext.ToListAsync()) :
                        Problem("problema");
        }

        public IActionResult CriarModal()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return PartialView("_CriarModal");
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

                return NotFound();
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
            return PartialView("_EditarModal", contato);
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
            return PartialView("_ApagarModal", contato);
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
