using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.Repositories
{
    class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(PortalContext context):base(context)
        {

        }
        public void Promocao(int id,decimal valor)
        {
            var professor = BuscarPorId(id);
            professor.Salario += professor.Salario* valor;
        }
    }
}
