using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.Repositories
{
    interface IGrupoRepository
    {
        void Cadastrar(Grupo grupo);
        void Atualizar(Grupo grupo);
        void Remover(int id);
        Aluno BuscarPorId(int Id);
        ICollection<Grupo> Listar();
        //ICollection<Grupo> BuscarPor(Expression<Func<Grupo, bool>> filtro);
    }
}
