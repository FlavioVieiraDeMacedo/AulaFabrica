using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Exemplo02.Models;

namespace Exemplo02.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private PortalContext _context;
        public AlunoRepository(PortalContext context)
        {
            _context = context;
        }
        public void Atualizar(Aluno aluno)
        {
            _context.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
        }

        public ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro)
        {
            return _context.Aluno.Where(filtro).ToList();
           
        }

        public Aluno BuscarPorId(int Id)
        {
            var aluno = _context.Aluno.Find(Id);
            return aluno;
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
        }

        public ICollection<Aluno> Listar()
        {
            return  _context.Aluno.ToList();
            
        }

        public void Remover(int id)
        {
            var aluno = _context.Aluno.Find(id);
            _context.Aluno.Remove(aluno);
        }
    }
}
