using Exemplo02.Models;
using Exemplo02.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class AlunoController : Controller
    {
        //private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastro()
        {
            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Aluno a)
        {
            _unit.AlunoRepository.Cadastrar(a);
            _unit.Salvar();
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastro");

        }
        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.AlunoRepository.Listar();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            return View(aluno);
        }
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            TempData["msg"] = "Aluno Deletado";
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca) {
            var lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            return View("Listar",lista);
        }
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}