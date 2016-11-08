using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.Repositories
{
    interface IAlunoRepository
    {
        void Cadastrar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Remover(int id);
        Aluno BuscarPorId(int Id);
        ICollection<Aluno> Listar();
        ICollection<Aluno> BuscarPor(Expression<Func<Aluno, bool>> filtro);
         
       
    }
}
