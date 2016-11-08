using Exemplo02.Models;
using Exemplo02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.UnitsOfWork
{
    class UnitOfWork : IDisposable
    {
        private PortalContext _context = new PortalContext();
        private IAlunoRepository _alunoRepository;
        private IGrupoRepository _grupoRepository;

        public IGrupoRepository GrupoRepository
        {
            get {
                if (_grupoRepository == null)
                {

                    _grupoRepository = new GrupoRepository(_context);
                }
                return _grupoRepository; }
        }


        public IAlunoRepository AlunoRepository
        {
            get {
                if (_alunoRepository == null)
                {

                    _alunoRepository = new AlunoRepository(_context);
                }
                return _alunoRepository; }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            if (_context!=null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }

   
}
