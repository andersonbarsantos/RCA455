using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Sistema
    {
        #region Propriedades

        public int IdSistema { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }
        public string Usuario { get; set; }

        #endregion

        #region Construtor

        public Sistema()
        {

        }

        #endregion


    }
}
