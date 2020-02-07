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
    public partial class Classificacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                DropDownSistema();
                ConsultaSemClassificar();
                ConsultaComClassificar();
            }
            else
            {
                if (string.IsNullOrEmpty(ddlSistema.SelectedValue))
                {
                    ConsultaComClassificar();
                    ConsultaSemClassificar();
                }
            }


        }

        protected void ConsultaSemClassificar()
        {
            RegraBLL r = new RegraBLL();

            List<Regra> lista = r.ConsultarSemClassif();

            gridSemClassificacao.DataSource = lista;
            gridSemClassificacao.DataBind();

            lblMensagemQntSem.Text = " ( " + lista.Count() + " Classificados)";

        }

        protected void ConsultaComClassificar()
        {
            RegraBLL r = new RegraBLL();

            List<Regra> lista = r.ConsultarComClassif();

            gridComClassificacao.DataSource = lista;
            gridComClassificacao.DataBind();

            lblMensagemCom.Text = " ( " + lista.Count() + " Classificados)";

        }

        protected void gridSemClassificacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSemClassificacao.PageIndex = e.NewPageIndex;
            gridSemClassificacao.DataBind();
        }

        protected void gridComClassificacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridComClassificacao.PageIndex = e.NewPageIndex;
            gridComClassificacao.DataBind();
        }

        protected void DropDownSistema()
        {
            DominioBLL d = new DominioBLL();

            List<Sistema> lista = d.BuscarTodosSistema();

            ddlSistema.DataSource = lista;
            ddlSistema.DataValueField = "IdSistema";
            ddlSistema.DataTextField = "Nome";
            ddlSistema.DataBind();

            ddlSistema.Items.Insert(0, new ListItem("- Selecione Sistema -", ""));

            if (string.IsNullOrEmpty(ddlSistema.SelectedValue))
            {
                ddlResponsavel.Enabled = false;
                ddlSituacao.Enabled = false;
                ddlTipo.Enabled = false;
                ddlRetorno.Enabled = false;
            }
         
        }

        protected void DropDownResponsavel()
        {
            DominioBLL d = new DominioBLL();

            Responsavel r = new Responsavel();
            Regra regra = new Regra();
            regra.Sistema = new Sistema();

            regra.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);

            List<Responsavel> lista = d.ConsultarResponsavel(regra.Sistema.IdSistema);

            ddlResponsavel.DataSource = lista;
            ddlResponsavel.DataValueField = "IdResponsavel";
            ddlResponsavel.DataTextField = "Nome";
            ddlResponsavel.DataBind();

            ddlResponsavel.Items.Insert(0, new ListItem("- Escolha Responsável -", ""));
        }

        protected void DropDownSituacao()
        {
            DominioBLL d = new DominioBLL();

            Situacao r = new Situacao();
            Regra regra = new Regra();
            regra.Sistema = new Sistema();
            regra.Responsavel = new Responsavel();

            regra.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
            regra.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
            List<Situacao> lista = d.ConsultarSituacao(regra.Sistema.IdSistema, regra.Responsavel.IdResponsavel);

            ddlSituacao.DataSource = lista;
            ddlSituacao.DataValueField = "IdSituacao";
            ddlSituacao.DataTextField = "Nome";
            ddlSituacao.DataBind();

            ddlSituacao.Items.Insert(0, new ListItem("- Escolha Situação -", ""));

        }

        protected void DropDownTipo()
        {
            DominioBLL d = new DominioBLL();

            Tipo t = new Tipo();
            Regra regra = new Regra();
            regra.Sistema = new Sistema();
            regra.Responsavel = new Responsavel();
            regra.Situacao = new Situacao();

            regra.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
            regra.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
            regra.Situacao.IdSituacao = int.Parse(ddlSituacao.SelectedValue);

            List<Tipo> lista = d.ConsultarTipo(regra.Sistema.IdSistema, regra.Responsavel.IdResponsavel, regra.Situacao.IdSituacao);

            ddlTipo.DataSource = lista;
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataTextField = "Nome";
            ddlTipo.DataBind();

            ddlTipo.Items.Insert(0, new ListItem("- Escolha Tipo -", ""));

        }

        protected void DropDownRetorno()
        {
            DominioBLL d = new DominioBLL();

            Retorno r = new Retorno();
            Regra regra = new Regra();
            regra.Sistema = new Sistema();
            regra.Responsavel = new Responsavel();
            regra.Situacao = new Situacao();
            regra.Tipo = new Tipo();

            regra.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
            regra.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
            regra.Situacao.IdSituacao = int.Parse(ddlSituacao.SelectedValue);
            regra.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);

            List<Retorno> lista = d.ConsultarTipo(regra.Sistema.IdSistema, regra.Responsavel.IdResponsavel, regra.Situacao.IdSituacao, regra.Tipo.IdTipo);

            ddlRetorno.DataSource = lista;
            ddlRetorno.DataValueField = "IdRetorno";
            ddlRetorno.DataTextField = "Nome";
            ddlRetorno.DataBind();

            ddlRetorno.Items.Insert(0, new ListItem("- Escolha Retorno -", ""));
        }

        protected void ddlSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSistema.SelectedValue))
            {
                ddlResponsavel.Enabled = true;
                ddlSituacao.Enabled = false;
                ddlTipo.Enabled = false;
                ddlRetorno.Enabled = false;

                DropDownResponsavel();
            }
        }

        protected void ddlResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSistema.SelectedValue) & !string.IsNullOrEmpty(ddlResponsavel.SelectedValue))
            {
                ddlSituacao.Enabled = true;
                ddlTipo.Enabled = false;
                ddlRetorno.Enabled = false;

                DropDownSituacao();
            }
        }

        protected void ddlSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSistema.SelectedValue) & !string.IsNullOrEmpty(ddlResponsavel.SelectedValue)
                & !string.IsNullOrEmpty(ddlSituacao.SelectedValue))
            {
                ddlTipo.Enabled = true;
                ddlRetorno.Enabled = false;

                DropDownTipo();
            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSistema.SelectedValue) & !string.IsNullOrEmpty(ddlResponsavel.SelectedValue)
                & !string.IsNullOrEmpty(ddlSituacao.SelectedValue) & !string.IsNullOrEmpty(ddlTipo.SelectedValue))
            {
                ddlRetorno.Enabled = true;
                DropDownRetorno();
            }
        }

        protected void ddlRetorno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ddlRetorno.SelectedValue = string.Empty;
            ddlTipo.SelectedValue = string.Empty;
            ddlSituacao.SelectedValue = string.Empty;
            ddlResponsavel.SelectedValue = string.Empty;

            DropDownSistema();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            List<Regra> listaRegras = new List<Regra>();
            Regra r = new Regra();
            r.Sistema = new Sistema();
            r.Responsavel = new Responsavel();
            r.Situacao = new Situacao();
            r.Tipo = new Tipo();
            r.Retorno = new Retorno();

            foreach (GridViewRow linha in gridSemClassificacao.Rows) 
            {
                CheckBox chkSemClass = linha.FindControl
                    ("chkSemClass") as CheckBox;

                if (chkSemClass.Checked)
                {
                    Label lblIdRegra = linha.FindControl
                        ("lblIdRegra") as Label;

                    r.Id_regra = int.Parse(lblIdRegra.Text);

                    listaRegras.Add(r);

                    r.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
                    r.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
                    r.Situacao.IdSituacao = int.Parse(ddlSituacao.SelectedValue);
                    r.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
                    r.Retorno.IdRetorno = int.Parse(ddlRetorno.SelectedValue);
                    r.DtAlteracao = DateTime.Now;
                    r.Usuario = "TesteUpd";

                    RegraBLL b = new RegraBLL();
                    b.AtualizarRegra(r);

                    lblMensagemClassificacao.Text = "Classificado com sucesso";
                }

                
              
            }

            ConsultaSemClassificar();

            foreach (GridViewRow linha in gridComClassificacao.Rows)
            {

                CheckBox chkComClass = linha.FindControl
                    ("chkComClass") as CheckBox;

                if (chkComClass.Checked)
                {
                    Label lblIdRegra2 = linha.FindControl
                        ("lblIdRegra2") as Label;

                    r.Id_regra = int.Parse(lblIdRegra2.Text);

                    listaRegras.Add(r);

                    r.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
                    r.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
                    r.Situacao.IdSituacao = int.Parse(ddlSituacao.SelectedValue);
                    r.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
                    r.Retorno.IdRetorno = int.Parse(ddlRetorno.SelectedValue);
                    r.DtAlteracao = DateTime.Now;
                    r.Usuario = "TesteUpd";

                    RegraBLL b = new RegraBLL();
                    b.AtualizarRegra(r);      

                    lblMensagemClassificacao.Text = "Classificado com sucesso";
                }

            }

            ConsultaComClassificar();
            //ConsultaSemClassificar();
        }
    }
}