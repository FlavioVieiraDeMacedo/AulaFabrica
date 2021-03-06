﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exemplo02.Models;
using Exemplo02.Repositories;
using System.Data.Entity.Infrastructure;

namespace Fiap.Exemplo02.Persistencia.Test
{
    /// <summary>
    /// Summary description for GenericRepositoryTest
    /// </summary>
    [TestClass]
    public class GenericRepositoryTest
    {
       
        private GenericRepository<Aluno> _repository;
        private PortalContext _context;
        [TestInitialize]
        public void Inicializacao() {
            _context = new PortalContext();
            _repository = new GenericRepository<Aluno>(_context);
        }
        [TestMethod]
        public void Cadastrar_Ok()
        {
            var aluno = new Aluno()
            {
                Nome="Teste",
                Bolsa=false,
                DataNascimento=DateTime.Now,
                Desconto=10,
                Grupo=new Grupo() { Nome = "Grupo Teste"}
            };
            _repository.Cadastrar(aluno);
            int r = _context.SaveChanges();
            Assert.AreNotEqual(aluno.Id, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void Grupo_Obrigatorio_Ok()
        {
            var aluno = new Aluno()
            {
                Nome = "Teste",
                Bolsa = false,
                DataNascimento = DateTime.Now,
                Desconto = 10
            };
            _repository.Cadastrar(aluno);
            _context.SaveChanges();
        }

    }
}
