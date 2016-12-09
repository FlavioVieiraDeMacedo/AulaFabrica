using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo05.MVC.Web.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        // GET: Cliente
        
        public ActionResult Index()
        {
            return View();
        }
    }
}