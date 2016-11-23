using Exemplo02.Models;
using Exemplo02.Repositories;
using System;

namespace Exemplo02.UnitsOfWork
{
    class UnitOfWork : IDisposable
    {
        #region Fields
        private PortalContext _context = new PortalContext();
        private IGenericRepository<Aluno> _alunoRepository;
        private IGrupoRepository _grupoRepository;
        private IProfessorRepository _professorRepository;
        #endregion
        #region Gets

        public IGrupoRepository GrupoRepository
        {
            get {
                if (_grupoRepository == null)
                {

                    _grupoRepository = new GrupoRepository(_context);
                }
                return _grupoRepository; }
        }


        public IGenericRepository<Aluno> AlunoRepository
        {
            get {
                if (_alunoRepository == null)
                {

                    _alunoRepository = new GenericRepository<Aluno>(_context);
                }
                return _alunoRepository; }
        }

        public IProfessorRepository ProfessorRepository
        {
            get
            {
                if (_professorRepository==null)
                {
                    _professorRepository = new ProfessorRepository(_context);
                }
                return _professorRepository;
            }
        }
        #endregion
        #region Salvar
        public void Salvar()
        {
            _context.SaveChanges();
        }
        #endregion
        #region Dispose
        public void Dispose()
        {
            if (_context!=null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    }


}
