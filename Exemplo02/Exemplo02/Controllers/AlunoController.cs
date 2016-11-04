using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class AlunoController : Controller
    {
        private PortalContext _context = new PortalContext();
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Aluno a)
        {

            _context.Aluno.Add(a);
            _context.SaveChanges();
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastro");

        }
        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Aluno.ToList();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var aluno = _context.Aluno.Find(id);


            return View(aluno);
        }
        public ActionResult Editar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            var aluno = _context.Aluno.Find(alunoId);
            _context.Aluno.Remove(aluno);
            _context.SaveChanges();
            TempData["msg"] = "Aluno Deletado";
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca) {
            var lista = _context.Aluno.Where(a => a.Nome.Contains(nomeBusca)).ToList();
            return View("Listar",lista);
        }
    }
}