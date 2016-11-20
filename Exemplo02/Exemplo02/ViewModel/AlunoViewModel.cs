using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo02.ViewModel
{
    public class AlunoViewModel
    {
        #region Aluno
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        public int GrupoId { get; set; }
        #endregion
        public SelectList ListaGrupo { get; set; }
        public string Mensagem { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
        public string NomeBusca { get; set; }
        public Nullable<int> IdBusca { get; set; }
    }
}