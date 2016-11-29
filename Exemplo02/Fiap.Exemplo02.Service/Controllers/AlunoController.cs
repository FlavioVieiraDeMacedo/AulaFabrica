using Exemplo02.Models;
using Exemplo02.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fiap.Exemplo02.Service.Controllers
{
    public class AlunoController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public ICollection<Aluno> Get()
        {
            return _unit.AlunoRepository.Listar();
        }
        public Aluno Get(int id)
        {
            return _unit.AlunoRepository.BuscarPorId(id);
        }
        public ICollection<Aluno> Get(string nome)
        {
            return _unit.AlunoRepository.BuscarPor(a => a.Nome == nome);
        }
        public IHttpActionResult Post(Aluno aluno)
        {
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            var uri = Url.Link("DefaultApi", new { id = aluno.Id });
            return Created<Aluno>(new Uri(uri), aluno);

        }
        public IHttpActionResult Put(int id, Aluno aluno)
        {
            aluno.Id = id;
            _unit.AlunoRepository.Alterar(aluno);
            _unit.Salvar();
            return Ok(aluno);
        }
        public void Delete(int id)
        {
            _unit.AlunoRepository.Remover(id);
            _unit.Salvar();
        }
    }
}
