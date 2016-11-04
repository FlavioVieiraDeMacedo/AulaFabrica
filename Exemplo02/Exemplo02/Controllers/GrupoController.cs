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
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var lista = _context.Grupo.ToList();
            return View(lista);
        }
    }
}