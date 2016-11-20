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
        #region GET
        [HttpGet]
        public ActionResult Cadastro()
        {
            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");
            return View();
        }
        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _unit.AlunoRepository.Listar();
            CarregarComboGrupos();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            return View(aluno);
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            ICollection<Aluno> lista;
            if (idGrupo == null)
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            }
            else
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);
            }
            CarregarComboGrupos();
            return View("Listar", lista);
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Cadastro(Aluno a)
        {
            _unit.AlunoRepository.Cadastrar(a);
            _unit.Salvar();
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastro");

        }
        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            TempData["msg"] = "Aluno Deletado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Alterar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }
        #endregion
        #region PRIVATE
        private void CarregarComboGrupos()
        {
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion
        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
        #endregion
    }
}