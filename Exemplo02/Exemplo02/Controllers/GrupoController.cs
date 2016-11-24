using Exemplo02.Models;
using Exemplo02.UnitsOfWork;
using Exemplo02.ViewModels;
using System.Web.Mvc;

namespace Exemplo02.Controllers
{
    public class GrupoController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();
        #region GET
        [HttpGet]
        public ActionResult Cadastrar(string msg)
        {
            var viewModel = new GrupoViewModel()
            {
                Mensagem = msg
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Listar(string msg)
        {
            var grupos = _unit.GrupoRepository.Listar();
            var grupoViewModel = new GrupoViewModel()
            {
                Mensagem = msg,
                Grupos = grupos
            };
            return View(grupoViewModel);
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var grupo = _unit.GrupoRepository.BuscarPorId(id);
            var grupoViewModel = ConverteEmGrupoView(grupo);
            return View(grupoViewModel);
        }
        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            var lista = _unit.GrupoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) || a.Projeto.Nome.Contains(nomeBusca));
            //var grupoViewModel = new GrupoViewModel()
            //{
            //   Grupos = lista
            //};
            return PartialView("_tabela", lista);
        }
        #endregion
        #region POST
        [HttpPost]
        public ActionResult Cadastrar(GrupoViewModel GrupoViewModel)
        {
            Grupo grupo = ConverteEmGrupo(GrupoViewModel);
            _unit.GrupoRepository.Cadastrar(grupo);
            _unit.Salvar();
            return RedirectToAction("Cadastrar", new { msg = "Grupo Cadastrado com sucesso!!" });
        }

        [HttpPost]
        public ActionResult Editar(GrupoViewModel grupoViewModel)
        {
            var grupo = ConverteEmGrupo(grupoViewModel);
            _unit.GrupoRepository.Alterar(grupo);
            _unit.Salvar();
            return RedirectToAction("Listar", new { msg = "Grupo Atualizado!!" });
        }
        [HttpPost]
        public ActionResult Excluir(int grupoId)
        {
            _unit.GrupoRepository.Remover(grupoId);
            _unit.Salvar();
            return RedirectToAction("Listar", new { msg = "Grupo Deletado!!" });
        }
        #endregion
        #region PRIVATE
        private GrupoViewModel ConverteEmGrupoView(Grupo grupo)
        {
            return new GrupoViewModel()
            {
                Id = grupo.Id,
                Nome = grupo.Nome,
                Nota = grupo.Nota,
                Projeto = grupo.Projeto
            };
        }
        private static Grupo ConverteEmGrupo(GrupoViewModel GrupoViewModel)
        {
            return new Grupo()
            {
                Id = GrupoViewModel.Id,
                Nome = GrupoViewModel.Nome,
                Nota = GrupoViewModel.Nota,
                Projeto = GrupoViewModel.Projeto
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