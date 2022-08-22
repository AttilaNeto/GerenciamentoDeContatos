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

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);

            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        
        public IActionResult Deletar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult EditarModal(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            return PartialView(contato);
        }

    }
}
