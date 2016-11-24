using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo02.ViewModels
{
    public class ProfessorViewModel
    {
        public string Mensagem { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public  ICollection<Aluno> Alunos { get; set; }
        public ICollection<Professor> Professores { get; set; }
        public Professor professor { get; set; }
        public string Nome2 { get; set; }
        public Nullable<decimal> Salario2 { get; set; }
    }
}