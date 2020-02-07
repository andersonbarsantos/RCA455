using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Regra
    {
       #region Propriedades

        public int Id_regra              { get; set; }
        public string Ativo { get; set; }
        public string Descricao          { get; set; }
        public int Quantidade            { get; set; }
        public DateTime DtInicioVigencia { get; set; }
        public DateTime DtFimVigencia    { get; set; }
        public Sistema Sistema           { get; set; }
        public Responsavel Responsavel   { get; set; }
        public Situacao Situacao         { get; set; }
        public Tipo Tipo                 { get; set; }
        public Retorno Retorno           { get; set; }
        public DateTime DtInclusao       { get; set; }
        public DateTime DtAlteracao      { get; set; }
        public string Usuario            {get; set;}
      

	   #endregion

        #region Construtor

        public Regra() 
        {
        
        }

        #endregion

    }
}
