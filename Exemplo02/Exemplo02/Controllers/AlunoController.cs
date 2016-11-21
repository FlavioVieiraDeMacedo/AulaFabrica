using Exemplo02.Models;
using Exemplo02.ViewModels;
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
        public ActionResult Cadastro(string msg)
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Mensagem = msg
            };
            return View(viewModel);
        }



        [HttpGet]
        public ActionResult Listar()
        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Alunos = _unit.AlunoRepository.Listar()
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            AlunoViewModel viewModel = ConverteEmAlunoView(aluno);
            return View(viewModel);
        }



        [HttpGet]
        public ActionResult Buscar(string nomeBusca, int? idGrupo)
        {
            var lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && (a.GrupoId == idGrupo || idGrupo == null));
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Alunos = lista
            };
            return View("Listar", viewModel);
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Cadastro(AlunoViewModel alunoViewModel)
        {
            var aluno = ConverteEmAluno(alunoViewModel);
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            return RedirectToAction("Cadastro", new { msg = "Aluno cadastradasso!" });

        }
        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Editar(AlunoViewModel alunoViewModel)
        {
            Aluno aluno = ConverteEmAluno(alunoViewModel);
            _unit.AlunoRepository.Alterar(aluno);
            _unit.Salvar();
            return RedirectToAction("Listar");
        }


        #endregion
        #region PRIVATE
        private void CarregarComboGrupos()
        {
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        private SelectList ListarGrupos()
        {
            var lista = _unit.GrupoRepository.Listar();
            return new SelectList(lista, "Id", "Nome");
        }
        private static Aluno ConverteEmAluno(AlunoViewModel alunoViewModel)
        {
            return new Aluno()
            {
                Nome = alunoViewModel.Nome,
                DataNascimento = alunoViewModel.DataNascimento,
                Bolsa = alunoViewModel.Bolsa,
                Desconto = alunoViewModel.Desconto,
                GrupoId = alunoViewModel.GrupoId
            };
        }
        private AlunoViewModel ConverteEmAlunoView(Aluno aluno)
        {
            return new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Nome = aluno.Nome,
                Bolsa = aluno.Bolsa,
                Desconto = aluno.Desconto,
                Id = aluno.Id,
                GrupoId = aluno.GrupoId,
                DataNascimento = aluno.DataNascimento
            };
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