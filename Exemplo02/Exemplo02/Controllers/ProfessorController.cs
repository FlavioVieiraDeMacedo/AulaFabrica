using Exemplo02.Models;
using Exemplo02.UnitsOfWork;
using Exemplo02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class ProfessorController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        // GET: Professor
        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            var viewModel = new ProfessorViewModel()
            {
                Mensagem = msg,
                Professores = _unit.ProfessorRepository.Listar()
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            var lista = _unit.ProfessorRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            var viewModel = new ProfessorViewModel
            {
                Professores = lista
            };
            return PartialView("_tabela", viewModel);

        }
        [HttpPost]
        public ActionResult Cadastrar(ProfessorViewModel professorViewModel)
        {
            var professor = new Professor()
            {
                Nome = professorViewModel.Nome,
                Id = professorViewModel.Id,
                Salario = professorViewModel.Salario

            };

            _unit.ProfessorRepository.Cadastrar(professor);
            _unit.Salvar();
            return RedirectToAction("Cadastrar", new { msg = "Professor cadastrado com sucesso!" });
        }
        [HttpPost]
        public ActionResult Excluir(int professorId)
        {
            _unit.ProfessorRepository.Remover(professorId);
            _unit.Salvar();
            return RedirectToAction("Cadastrar", new { msg = "Professor Deletado com sucesso!" });
        }
        [HttpPost]
        public ActionResult Editar(ProfessorViewModel professorViewModel) {
            var professor = new Professor
            {
                Nome=professorViewModel.Nome2,
                Salario = professorViewModel.Salario2,
                Id=professorViewModel.Id
            };
            _unit.ProfessorRepository.Alterar(professor);
            _unit.Salvar();
            return RedirectToAction("Cadastrar", new { msg = "Professor Alterado com sucesso!" });
        }    
    }
}