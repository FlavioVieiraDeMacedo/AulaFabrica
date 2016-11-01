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
        // GET: Aluno
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Aluno a) {
            var _context = new PortalContext();
            _context.Aluno.Add(a);
            _context.SaveChanges();            TempData["msg"] = "Aluno cadastrado!";            return RedirectToAction("Cadastro");
        }
        public ActionResult Listar()
        {
            return View();
        }    

    }

    
}