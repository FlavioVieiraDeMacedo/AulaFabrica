using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected PortalContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(PortalContext context) {
            _context = context;
            _dbSet = _context.Set<T>();        }
        public virtual void Alterar(T entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual ICollection<T> BuscarPor(System.Linq.Expressions.Expression<Func<T, bool>> filtrar)
        {
            return _dbSet.Where(filtrar).ToList();
        }

        public virtual T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
        }

        public virtual ICollection<T> Listar()
        {
            return _dbSet.ToList();
        }

        public virtual void Remover(int id)
        {
            var entity = BuscarPorId(id);
            _dbSet.Remove(entity);
        }
    }
}
