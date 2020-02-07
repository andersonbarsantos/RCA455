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
    public partial class CadastrarRegras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownSistema();
                DropDownResponsavel();
                DropDownSituacao();
                DropDownTipo();
                DropDownRetorno();
                ConsultarRegra();

                lblMensagemExcl.Text = string.Empty;
                lblMensagemSalvar.Text = string.Empty;

            }

            btnExcluir.Attributes["onClick"] = "return confirm('Deseja excluir a regra selecionada na lista?');";
        }

        protected void DropDownSistema()
        {
            DominioBLL d = new DominioBLL();

            List<Sistema> lista = d.BuscarTodosSistema();

            ddlSistema.DataSource = lista;
            ddlSistema.DataValueField = "IdSistema";
            ddlSistema.DataTextField = "Nome";
            ddlSistema.DataBind();

            ddlSistema.Items.Insert(0, new ListItem("- Escolha Sistema -", ""));

        }

        protected void DropDownResponsavel()
        {
            DominioBLL d = new DominioBLL();

            List<Responsavel> lista = d.BuscarTodosResp();

            ddlResponsavel.DataSource = lista;
            ddlResponsavel.DataValueField = "IdResponsavel";
            ddlResponsavel.DataTextField = "Nome";
            ddlResponsavel.DataBind();

            ddlResponsavel.Items.Insert(0, new ListItem("- Escolha Responsável -", ""));

        }

        protected void DropDownSituacao()
        {
            DominioBLL d = new DominioBLL();

            List<Situacao> lista = d.BuscarTodosSituacao();

            ddlSituacao.DataSource = lista;
            ddlSituacao.DataValueField = "IdSituacao";
            ddlSituacao.DataTextField = "Nome";
            ddlSituacao.DataBind();

            ddlSituacao.Items.Insert(0, new ListItem("- Escolha Situação -", ""));

        }

        protected void DropDownTipo()
        {
            DominioBLL d = new DominioBLL();

            List<Tipo> lista = d.BuscarTodosTipo();

            ddlTipo.DataSource = lista;
            ddlTipo.DataValueField = "IdTipo";
            ddlTipo.DataTextField = "Nome";
            ddlTipo.DataBind();

            ddlTipo.Items.Insert(0, new ListItem("- Escolha Tipo -", ""));

        }

        protected void DropDownRetorno()
        {
            DominioBLL d = new DominioBLL();

            List<Retorno> lista = d.BuscarTodosRetorno();

            ddlRetorno.DataSource = lista;
            ddlRetorno.DataValueField = "IdRetorno";
            ddlRetorno.DataTextField = "Nome";
            ddlRetorno.DataBind();

            ddlRetorno.Items.Insert(0, new ListItem("- Escolha Retorno -", ""));
        }

        protected void ConsultarRegra()
        {
            RegraBLL b = new RegraBLL();
            List<Regra> lista = b.ConsultarTodos();

            gridRegras.DataSource = lista;
            gridRegras.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            RegraBLL b = new RegraBLL();

            Regra r = new Regra();
            r.Sistema = new Sistema();
            r.Responsavel = new Responsavel();
            r.Situacao = new Situacao();
            r.Tipo = new Tipo();
            r.Retorno = new Retorno();

            r.Sistema.IdSistema = int.Parse(ddlSistema.SelectedValue);
            r.Responsavel.IdResponsavel = int.Parse(ddlResponsavel.SelectedValue);
            r.Situacao.IdSituacao = int.Parse(ddlSituacao.SelectedValue);
            r.Tipo.IdTipo = int.Parse(ddlTipo.SelectedValue);
            r.Retorno.IdRetorno = int.Parse(ddlRetorno.SelectedValue);
            r.Descricao = txtDescricao.Text;
            r.Ativo = "n";

            if (checkRegra.Checked)
            {
                r.Ativo = "s";
            }

            r.DtInicioVigencia = DateTime.Now;
            r.DtInclusao = DateTime.Now;
            r.Usuario = "Teste";

            b.InserirRegra(r);

            ddlSistema.SelectedValue = string.Empty;
            ddlResponsavel.SelectedValue = string.Empty;
            ddlSituacao.SelectedValue = string.Empty;
            ddlTipo.SelectedValue = string.Empty;
            ddlRetorno.SelectedValue = string.Empty;
            txtDescricao.Text = string.Empty;
            checkRegra.Checked = false;

            ConsultarRegra();

            lblMensagemSalvar.Text = "Regra cadastrada com sucesso!";
            lblMensagemExcl.Text = string.Empty;
           
        }

        
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            
               RegraBLL b = new RegraBLL();

               Regra r = new Regra();
               r.Sistema = new Sistema();
               r.Responsavel = new Responsavel();
               r.Situacao = new Situacao();
               r.Tipo = new Tipo();
               r.Retorno = new Retorno();
               List<Regra> lista = new List<Regra>();

               foreach (GridViewRow linha in gridRegras.Rows)
               {
                   CheckBox chkRegra = linha.FindControl
                       ("chkRegra") as CheckBox;

                   //verificar se o checkbox esta marcado..
                   if (chkRegra.Checked)
                   {
                       Label lblIdRegra = linha.FindControl
                       ("lblIdRegra") as Label;

                       r.Id_regra = int.Parse(lblIdRegra.Text);

                       lista.Add(r);

                       b.ExcluirRegra(r.Id_regra);
                   }
               }

               lblMensagemExcl.Text = Convert.ToString(lista.Count) + " registro(s) excluído(s).";

               ConsultarRegra();
           
        }

        protected void gridRegras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRegras.PageIndex = e.NewPageIndex;
            gridRegras.DataBind();

            ConsultarRegra();
        }

    }
}