using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class GrupoController : Controller
    {
        private PortalContext _context = new PortalContext();
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Grupo g)
        {
            _context.Grupo.Add(g);
            _context.SaveChanges();
            TempData["msg"] = "Grupo cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Grupo.ToList();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var grupo = _context.Grupo.Find(id);
            return View(grupo);
        }
        [HttpPost]
        public ActionResult Editar(Grupo grupo)
        {
            _context.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(grupo.Projeto).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Grupo atualizado";
            return RedirectToAction("Listar");
        }
        [HttpPost]
        public ActionResult Excluir(int grupoId)
        {
            var grupo = _context.Grupo.Find(grupoId);

            _context.Projeto.Remove(grupo.Projeto);
            _context.Grupo.Remove(grupo);
            _context.SaveChanges();
            TempData["msg"] = "Grupo Deletado";
            return RedirectToAction("Listar");
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            var lista = _context.Grupo.Where(a => a.Nome.Contains(nomeBusca) || a.Projeto.Nome.Contains(nomeBusca)).ToList();
            return View("Listar", lista);
        }
    }
}