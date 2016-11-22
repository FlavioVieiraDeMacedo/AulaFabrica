using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo02.ViewModels
{
    public class GrupoViewModel
    {
        public string Mensagem { get; set; }
        #region atributos Grupo
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<double> Nota { get; set; }
        public Projeto Projeto { get; set; }
        #endregion
        #region atributos Lista
        public ICollection<Grupo> Grupos { get; set; }
        public string NomeBusca { get; set; }
        #endregion
    }
}   