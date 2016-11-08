using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exemplo02.Models;

namespace Exemplo02.Repositories
{
    class GrupoRepository : IGrupoRepository
    {
        private PortalContext _context;
        public GrupoRepository(PortalContext context)
        {
            _context = context;
        }
        public void Atualizar(Grupo grupo)
        {
            _context.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
        }

        public Aluno BuscarPorId(int Id)
        {
            var aluno = _context.Aluno.Find(Id);
            return aluno;
        }

        public void Cadastrar(Grupo grupo)
        {
            _context.Grupo.Add(grupo);
        }

        public ICollection<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }

        public void Remover(int id)
        {
            var grupo = _context.Grupo.Find(id);
            _context.Grupo.Remove(grupo);
        }
    }
}
