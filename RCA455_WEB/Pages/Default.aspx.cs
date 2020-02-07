using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using RegrasBLL;

namespace RCA455_WEB.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Consultar();
        }

        protected void Consultar()
        {
            RegraBLL regra = new RegraBLL();

            List<Regra> lista = regra.ConsultaInicial();

            gridClassificacoes.DataSource = lista;
            gridClassificacoes.DataBind();

            lblDataClassificações.Text = Convert.ToString(string.Format("{0:dd/MM/yyyy}", DateTime.Today));

        }

        protected void gridClassificacoes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridClassificacoes.PageIndex = e.NewPageIndex;
            gridClassificacoes.DataBind();

        }


    }
}