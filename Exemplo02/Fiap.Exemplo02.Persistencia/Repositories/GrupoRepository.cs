using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo02.Repositories
{
    class GrupoRepository : GenericRepository<Grupo>,IGrupoRepository
    {
        public GrupoRepository(PortalContext context):base(context)
        {

        }
        public override void Alterar(Grupo entidade)
        {
            _context.Entry(entidade.Projeto).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }
        public override void Remover(int id)
        {
            var entity = BuscarPorId(id);
            var projeto = BuscarPorId(entity.Projeto.Id);
            _dbSet.Remove(projeto);
            _dbSet.Remove(entity);
        }

    }
}