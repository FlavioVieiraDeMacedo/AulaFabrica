﻿using Exemplo02.Models;
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
        
        private UnitOfWork _unit = new UnitOfWork();

        #region GET
        [HttpGet]
        public ActionResult ValidarNome(string nome)
        {
            var aluno = _unit.AlunoRepository.BuscarPor(a => a.Nome == nome);
            return Json(new { existe = aluno.Any() },JsonRequestBehavior.AllowGet );
        }
        [HttpGet]

        public ActionResult Cadastro(string msg)

        {
            var viewModel = new AlunoViewModel()
            {
                ListaGrupo = ListarGrupos(),
                Mensagem = msg,
                DataNascimento = DateTime.Now
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
            //var viewModel = new AlunoViewModel()
            //{
            //   ListaGrupo = ListarGrupos(),
            //    Alunos = lista
            //};
            return PartialView("_tabela", lista);
            
        }
        #endregion
        #region POST
        [HttpPost]

        public ActionResult Cadastro(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = ConverteEmAluno(alunoViewModel);
                if (VerificaNomeAlunoUnico(aluno.Nome))
                {
                    _unit.AlunoRepository.Cadastrar(aluno);
                    try
                    {
                        _unit.Salvar();
                        return RedirectToAction("Cadastro", new { msg = "Aluno cadastradasso!" });
                    }
                    catch (Exception e)
                    {
                        alunoViewModel.Mensagem = "Deu Ruim - " + e.Message;
                        alunoViewModel.ListaGrupo = ListarGrupos();
                        return View(alunoViewModel);
                    }
                    
                    
                }
                else
                {
                    alunoViewModel.ListaGrupo = ListarGrupos();
                    alunoViewModel.Mensagem = "Nome Já Cadastrado";
                    return View(alunoViewModel);
                }
            }
            else
            {
                alunoViewModel.ListaGrupo = ListarGrupos();
                return View(alunoViewModel);
            }
            
            


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
        private bool VerificaNomeAlunoUnico(string Nome)
        {
            var aluno =_unit.AlunoRepository.BuscarPor(a => a.Nome == Nome);
            var cont = 0;
            
            foreach (var item in aluno)
            {
                if (item.Nome!=null)
                {
                    cont++;
                }
            }
            return cont == 0 ? true : false;
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
                Id=alunoViewModel.Id,
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