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
    public partial class Cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Consultar();
                ConsultarSistema();
                ConsultarSituacao();
                ConsultarTipo();
                ConsultarRetorno();

                lblMensagemSalvarRes.Text = string.Empty;
                lblMensagemExcRes.Text = string.Empty;

            }

            btnExcluirResp.Attributes["onClick"]    = "return confirm('Deseja excluir o Responsável selecionado?');";
            btnExcluirSist.Attributes["onClick"]    = "return confirm('Deseja excluir o Sistema selecionado?');";
            btnExcluirSitu.Attributes["onClick"]    = "return confirm('Deseja excluir a Situação selecionada?');";
            btnExcluirTipo.Attributes["onClick"]    = "return confirm('Deseja excluir o Tipo selecionado?');";
            btnExcluirRetorno.Attributes["onClick"] = "return confirm('Deseja excluir o Retorno selecionado?');";

        }

        #region Responsavel
        protected void Consultar()
        {
            DominioBLL d = new DominioBLL();

            List<Responsavel> listaResp = d.BuscarTodosResp();

            gridConsultaResp.DataSource = listaResp;
            gridConsultaResp.DataBind();
        }



        protected void btnSalvarResp_Click(object sender, EventArgs e)
        {
            Responsavel r = new Responsavel();

            r.Nome = txtResponsavel.Text;
            r.Descricao = txtDescricaoResp.Text;
            r.DtInclusao = DateTime.Now;
            r.Usuario = "Teste";

            DominioBLL d = new DominioBLL();

            d.InserirResp(r);

            txtResponsavel.Text = string.Empty;
            txtDescricaoResp.Text = string.Empty;

            lblMensagemSalvarRes.Text = "Responsável cadastrado com sucesso!";
            lblMensagemExcRes.Text = string.Empty;

            Consultar();

        }

        protected void btnExcluirResp_Click(object sender, EventArgs e)
        {
            List<Responsavel> listaResponsavel = new List<Responsavel>();
            
            Responsavel r = new Responsavel();
            //btnExcluirResp.Attributes["onClick"] = "return confirm('Deseja excluir o Responsável selecionado?');";
            foreach (GridViewRow linha in gridConsultaResp.Rows)
            {

                CheckBox chkResponsavel = linha.FindControl
                ("chkResponavel") as CheckBox;
                //verificar se o checkbox esta marcado..
                if (chkResponsavel.Checked)
                {
                    
                    Label lblIdResponsavel = linha.FindControl
                    ("lblIdResponsavel") as Label;

                    r.IdResponsavel = int.Parse(lblIdResponsavel.Text);

                    DominioBLL d = new DominioBLL();
                    d.ExcluirResp(r.IdResponsavel);

                    listaResponsavel.Add(r);
                    
                   ;
                }
            }

            lblMensagemExcRes.Text = Convert.ToString(listaResponsavel.Count) + " registro(s) excluído(s).";

            txtResponsavel.Text = string.Empty;
            txtDescricaoResp.Text = string.Empty;

            Consultar();
        }


        protected void btnAtualizarResp_Click(object sender, EventArgs e)
        {
            List<Responsavel> listaResponsavel = new List<Responsavel>();

            Responsavel r = new Responsavel();

            foreach (GridViewRow linha in gridConsultaResp.Rows)
            {

                CheckBox chkResponsavel = linha.FindControl
                ("chkResponavel") as CheckBox;
                //verificar se o checkbox esta marcado..
                if (chkResponsavel.Checked)
                {

                    Label lblIdResponsavel = linha.FindControl
                    ("lblIdResponsavel") as Label;


                    r.IdResponsavel = int.Parse(lblIdResponsavel.Text);
                    //adicionar na lista..
                    listaResponsavel.Add(r);
                }
            }

            r.Nome = txtResponsavel.Text;
            r.Descricao = txtDescricaoResp.Text;
            r.DtAlteracao = DateTime.Now;
            r.Usuario = "TesteUpd";

            DominioBLL d = new DominioBLL();
            d.AtualizarResp(r);

            txtResponsavel.Text = string.Empty;
            txtDescricaoResp.Text = string.Empty;

            lblMensagemExcRes.Text = Convert.ToString(listaResponsavel.Count) + " registro(s) atualizado(s).";
            lblMensagemSalvarRes.Text = string.Empty;

            Consultar();
        }

        protected void gridConsultaResp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridConsultaResp.PageIndex = e.NewPageIndex;
            gridConsultaResp.DataBind();
        }

        #endregion

        #region Sistema
        protected void ConsultarSistema()
        {
            DominioBLL d = new DominioBLL();

            List<Sistema> listaSistema = d.BuscarTodosSistema();

            gridSistema.DataSource = listaSistema;
            gridSistema.DataBind();

        }

        protected void btnSalvarSist_Click(object sender, EventArgs e)
        {
            Sistema s = new Sistema();

            s.Nome = txtSistema.Text;
            s.Descricao = txtDescricaoSist.Text;
            s.DtInclusao = DateTime.Now;
            s.Usuario = "Teste";

            DominioBLL d = new DominioBLL();
            d.InserirSistema(s);

            txtSistema.Text = string.Empty;
            txtDescricaoSist.Text = string.Empty;

            //lblMensagemSalvar.Text = "Sistema cadastrado com sucesso!";

            ConsultarSistema();
        }

        protected void btnExcluirSist_Click(object sender, EventArgs e)
        {
            List<Sistema> listaSistema = new List<Sistema>();

            Sistema s = new Sistema();

            foreach (GridViewRow linha in gridSistema.Rows)
            {
                CheckBox chkSistema = linha.FindControl
                    ("chkSistema") as CheckBox;

                if (chkSistema.Checked)
                {
                    Label lblIdSistema = linha.FindControl
                        ("lblIdSistema") as Label;

                    s.IdSistema = int.Parse(lblIdSistema.Text);

                    listaSistema.Add(s);
                }

                DominioBLL d = new DominioBLL();
                d.ExcluirSistema(s.IdSistema);
            }

            txtSistema.Text = string.Empty;
            txtDescricaoSist.Text = string.Empty;

            ConsultarSistema();

        }

        protected void btnAtualizarSist_Click(object sender, EventArgs e)
        {
            List<Sistema> listaSistema = new List<Sistema>();

            Sistema s = new Sistema();

            foreach (GridViewRow linha in gridSistema.Rows)
            {
                CheckBox chkSistema = linha.FindControl
                    ("chkSistema") as CheckBox;

                if (chkSistema.Checked)
                {
                    Label lblIdSistema = linha.FindControl
                        ("lblIdSistema") as Label;

                    s.IdSistema = int.Parse(lblIdSistema.Text);

                    listaSistema.Add(s);
                }

                s.Nome = txtSistema.Text;
                s.Descricao = txtDescricaoSist.Text;
                s.DtAlteracao = DateTime.Now;
                s.Usuario = "TesteUp";

                DominioBLL d = new DominioBLL();
                d.AtualizarSistema(s);
            }

            txtSistema.Text = string.Empty;
            txtDescricaoSist.Text = string.Empty;

            ConsultarSistema();

        }
        protected void gridSistema_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSistema.PageIndex = e.NewPageIndex;
            gridSistema.DataBind();
        }

        #endregion

        #region Situacao
        protected void ConsultarSituacao()
        {
            DominioBLL d = new DominioBLL();

            List<Situacao> listaSituacao = d.BuscarTodosSituacao();

            gridSituacao.DataSource = listaSituacao;
            gridSituacao.DataBind();

        }

        protected void btnSalvarSitu_Click(object sender, EventArgs e)
        {
            Situacao s = new Situacao();

            s.Nome = txtSituacao.Text;
            s.Descricao = txtDescricaoSitu.Text;
            s.DtInclusao = DateTime.Now;
            s.Usuario = "Teste";

            DominioBLL d = new DominioBLL();
            d.InserirSituacao(s);

            txtSituacao.Text = string.Empty;
            txtDescricaoSitu.Text = string.Empty;

            ConsultarSituacao();

        }

        protected void btnExcluirSitu_Click(object sender, EventArgs e)
        {
            List<Situacao> listaSituacao = new List<Situacao>();

            Situacao s = new Situacao();

            foreach (GridViewRow linha in gridSituacao.Rows)
            {
                CheckBox chkSit = linha.FindControl
                    ("chkSit") as CheckBox;

                if (chkSit.Checked)
                {
                    Label lblIdSit = linha.FindControl
                        ("lblIdSit") as Label;

                    s.IdSituacao = int.Parse(lblIdSit.Text);

                    listaSituacao.Add(s);
                }

                DominioBLL d = new DominioBLL();
                d.ExcluirSituacao(s.IdSituacao);
            }

            txtSituacao.Text = string.Empty;
            txtDescricaoSitu.Text = string.Empty;

            ConsultarSituacao();

        }

        protected void btnAtualizarSitu_Click(object sender, EventArgs e)
        {
            List<Situacao> listaSituacao = new List<Situacao>();

            Situacao s = new Situacao();

            foreach (GridViewRow linha in gridSituacao.Rows)
            {
                CheckBox chkSit = linha.FindControl
                    ("chkSit") as CheckBox;

                if (chkSit.Checked)
                {
                    Label lblIdSit = linha.FindControl
                        ("lblIdSit") as Label;

                    s.IdSituacao = int.Parse(lblIdSit.Text);

                    listaSituacao.Add(s);
                }

                s.Nome = txtSituacao.Text;
                s.Descricao = txtDescricaoSitu.Text;
                s.DtAlteracao = DateTime.Now;
                s.Usuario = "TesteUp";

                DominioBLL d = new DominioBLL();
                d.AtualizarSituacao(s);                
            }

            txtSituacao.Text = string.Empty;
            txtDescricaoSitu.Text = string.Empty;

            ConsultarSituacao();
        }

        protected void gridSituacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSituacao.PageIndex = e.NewPageIndex;
            gridSituacao.DataBind();
        }

        #endregion

        #region Tipo
        protected void ConsultarTipo()
        {
            DominioBLL d = new DominioBLL();

            List<Tipo> listaTipo = d.BuscarTodosTipo();

            gridTipo.DataSource = listaTipo;
            gridTipo.DataBind();

        }

        protected void btnSalvarTipo_Click(object sender, EventArgs e)
        {
            Tipo t = new Tipo();

            t.Nome = txtTipo.Text;
            t.Descricao = txtDescricaoTipo.Text;
            t.DtInclusao = DateTime.Now;
            t.Usuario = "Teste";

            DominioBLL d = new DominioBLL();
            d.InserirTipo(t);

            txtTipo.Text = string.Empty;
            txtDescricaoTipo.Text = string.Empty;

            ConsultarTipo();

        }

        protected void btnExcluirTipo_Click(object sender, EventArgs e)
        {
            List<Tipo> listaTipo = new List<Tipo>();

            Tipo t = new Tipo();

            foreach (GridViewRow linha in gridTipo.Rows)
            {
                CheckBox chkTipo = linha.FindControl
                    ("chkTipo") as CheckBox;

                if (chkTipo.Checked)
                {
                    Label lblIdTipo = linha.FindControl
                        ("lblIdTipo") as Label;

                    t.IdTipo = int.Parse(lblIdTipo.Text);

                    listaTipo.Add(t);
                }

                DominioBLL d = new DominioBLL();
                d.ExcluirTipo(t.IdTipo);
            }

            txtTipo.Text = string.Empty;
            txtDescricaoTipo.Text = string.Empty;

            ConsultarTipo();
        }

        protected void btnAtualizarTipo_Click(object sender, EventArgs e)
        {
            List<Tipo> listaTipo = new List<Tipo>();

            Tipo t = new Tipo();

            foreach (GridViewRow linha in gridTipo.Rows)
            {
                CheckBox chkTipo = linha.FindControl
                    ("chkTipo") as CheckBox;

                if (chkTipo.Checked)
                {
                    Label lblIdTipo = linha.FindControl
                        ("lblIdTipo") as Label;

                    t.IdTipo = int.Parse(lblIdTipo.Text);

                    listaTipo.Add(t);
                }

                t.Nome = txtTipo.Text;
                t.Descricao = txtDescricaoTipo.Text;
                t.DtAlteracao = DateTime.Now;
                t.Usuario = "TesteUp";

                DominioBLL d = new DominioBLL();
                d.AtualizarTipo(t);
            }

            txtTipo.Text = string.Empty;
            txtDescricaoTipo.Text = string.Empty;

            ConsultarTipo();
        }

        protected void gridTipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridTipo.PageIndex = e.NewPageIndex;
            gridTipo.DataBind();
        }

        #endregion

        #region Retorno
        protected void ConsultarRetorno()
        {
            DominioBLL d = new DominioBLL();

            List<Retorno> listaRetorno = d.BuscarTodosRetorno();

            gridRetorno.DataSource = listaRetorno;
            gridRetorno.DataBind();

        }

        protected void btnSalvarRetorno_Click(object sender, EventArgs e)
        {
            Retorno r = new Retorno();

            r.Nome = txtRetorno.Text;
            r.Descricao = txtDescricaoRet.Text;
            r.DtInclusao = DateTime.Now;
            r.Usuario = "Teste";

            DominioBLL d = new DominioBLL();
            d.InserirRetorno(r);

            txtRetorno.Text = string.Empty;
            txtDescricaoRet.Text = string.Empty;

            ConsultarRetorno();
        }

        protected void btnExcluirRetorno_Click(object sender, EventArgs e)
        {
            List<Retorno> listaRetorno = new List<Retorno>();

            Retorno r = new Retorno();

            foreach (GridViewRow linha in gridRetorno.Rows)
            {
                CheckBox chkRetorno = linha.FindControl
                    ("chkRetorno") as CheckBox;

                if (chkRetorno.Checked)
                {
                    Label lblIdRetorno = linha.FindControl
                        ("lblIdRetorno") as Label;

                    r.IdRetorno = int.Parse(lblIdRetorno.Text);

                    listaRetorno.Add(r);
                }

                DominioBLL d = new DominioBLL();
                d.ExcluirRetorno(r.IdRetorno);
            }

            txtRetorno.Text = string.Empty;
            txtDescricaoRet.Text = string.Empty;

            ConsultarRetorno();
        }

        protected void btnAtualizarRetorno_Click(object sender, EventArgs e)
        {
            List<Retorno> listaRetorno = new List<Retorno>();

            Retorno r = new Retorno();

            foreach (GridViewRow linha in gridRetorno.Rows)
            {
                CheckBox chkRetorno = linha.FindControl
                    ("chkRetorno") as CheckBox;

                if (chkRetorno.Checked)
                {
                    Label lblIdRetorno = linha.FindControl
                        ("lblIdRetorno") as Label;

                    r.IdRetorno = int.Parse(lblIdRetorno.Text);

                    listaRetorno.Add(r);
                }

                r.Nome = txtRetorno.Text;
                r.Descricao = txtDescricaoRet.Text;
                r.DtAlteracao = DateTime.Now;
                r.Usuario = "TesteUp";

                DominioBLL d = new DominioBLL();
                d.AtualizarRetorno(r);
            }

            txtRetorno.Text = string.Empty;
            txtDescricaoRet.Text = string.Empty;

            ConsultarRetorno();
        }

        protected void gridRetorno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRetorno.PageIndex = e.NewPageIndex;
            gridRetorno.DataBind();
        }


        protected void ConfirmaApagar_Click(object sender, EventArgs e)
        {
        }

        #endregion

    }
}

