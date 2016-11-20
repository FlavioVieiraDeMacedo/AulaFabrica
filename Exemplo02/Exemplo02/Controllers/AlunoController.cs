using Exemplo02.Models;
using Exemplo02.UnitsOfWork;
using Exemplo02.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class AlunoController : Controller
    {
        
        private UnitOfWork _unit = new UnitOfWork();
        
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
        public ActionResult Cadastro(AlunoViewModel alunoViewModel)
        {
            var aluno = new Aluno()
            {
                Nome = alunoViewModel.Nome,
                DataNascimento = alunoViewModel.DataNascimento,
                Desconto = alunoViewModel.Desconto,
                Id = alunoViewModel.Id,
                GrupoId = alunoViewModel.GrupoId,
                Bolsa = alunoViewModel.Bolsa
            };

            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            var viewModel = new AlunoViewModel()
            {
                Mensagem = "Aluno cadastrado002",
                ListaGrupo = ListarGrupos()

            };
            return RedirectToAction("Cadastro", new { msg = "Aluno Cadastrado001" });

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
        private SelectList ListarGrupos()
        {
            var lista = _unit.GrupoRepository.Listar();
            return new SelectList(lista, "Id", "Nome");
        }
        /*private void CarregarComboGrupos()
        {
            //enviar para a tela os grupos para o "select"
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }*/
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