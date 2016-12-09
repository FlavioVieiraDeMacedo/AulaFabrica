using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exemplo02.Controllers;
using Exemplo02.ViewModels;
using System.Web.Mvc;
using Exemplo02.Models;

namespace Fiap.Exemplo02.Web.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Cadastrar_Get()
        {
            AlunoController controller = new AlunoController();
            var result = (ViewResult)controller.Cadastro("qwert");
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }
        [TestMethod]
        public void Cadastrar_Post()
        {
            AlunoController controller = new AlunoController();
            
            var aluno = new AlunoViewModel
            {
                Nome = "Tasdahjjhhj",
                Bolsa = false,
                DataNascimento = DateTime.Now,
                Desconto = 10,
                GrupoId = 1
                
            };
            var result = (RedirectToRouteResult)controller.Cadastro(aluno);
            Assert.IsNotNull(result);
            var modelResultado = result.RouteName;
            Assert.AreEqual(modelResultado, "Cadastro");
        }
    }
}
