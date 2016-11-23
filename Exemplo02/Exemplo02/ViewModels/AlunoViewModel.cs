using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Exemplo02.ViewModels
{
    public class AlunoViewModel
    {
        public SelectList ListaGrupo { get; set; }

        public string Mensagem { get; set; }

        #region Localizacao
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        #endregion

        #region Lista properties
        public ICollection<Aluno> Alunos { get; set; }
        public string NomeBusca { get; set; }
        public int? IdBusca { get; set; }
        #endregion

        #region Aluno properties
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Nullable<double> Desconto { get; set; }
        public bool Bolsa { get; set; }
        public int GrupoId { get; set; }
        #endregion
    }
}