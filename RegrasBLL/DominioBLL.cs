using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using RCA455_Conexao;

namespace RegrasBLL
{
    public class DominioBLL
    {
        //Responsável
        #region Responsável
        public void InserirResp(Responsavel r)
        {
            RepResponsavel rep = new RepResponsavel();
            rep.Insert(r);
        }

        public List<Responsavel> BuscarTodosResp()
        {
            RepResponsavel rep = new RepResponsavel();
            return rep.FindAll();
        }

        public List<Responsavel> ConsultarResponsavel(int sistema_id)
        {
            RepResponsavel rep = new RepResponsavel();

            return rep.FindBySist(sistema_id);
        }
       

        public void AtualizarResp(Responsavel r)
        {
            RepResponsavel rep = new RepResponsavel();
            if (rep.FindById(r.IdResponsavel) != null)
            {
                rep.UpdateAll(r);
            }

        }

        public void ExcluirResp(int responsavel_id)
        {
            RepResponsavel rep = new RepResponsavel();

            if (rep.FindById(responsavel_id) != null)
            {
                rep.Delete(responsavel_id);
            }
        }
        #endregion


        //Sistema 

        #region Sistema
        public void InserirSistema(Sistema s)
        {
            RepSistema rep = new RepSistema();
            rep.Insert(s);
        }

        public List<Sistema> BuscarTodosSistema()
        {
            RepSistema rep = new RepSistema();
            return rep.FindAll();
        }

        public void AtualizarSistema(Sistema s)
        {
            RepSistema rep = new RepSistema();
            if (rep.FindById(s.IdSistema) != null)
            {
                rep.UpdateAll(s);
            }

        }

        public void ExcluirSistema(int sistema_id)
        {
            RepSistema rep = new RepSistema();

            if (rep.FindById(sistema_id) != null)
            {
                rep.Delete(sistema_id);
            }
        }
        #endregion

        //Situacao

        #region Situacao
        public void InserirSituacao(Situacao s)
        {
            RepSituacao rep = new RepSituacao();
            rep.Insert(s);
        }

        public List<Situacao> BuscarTodosSituacao()
        {
            RepSituacao rep = new RepSituacao();
            return rep.FindAll();
        }

        public List<Situacao> ConsultarSituacao(int sistema_id, int responsavel_id)
        {
            RepSituacao rep = new RepSituacao();

            return rep.FindBySistRes(sistema_id, responsavel_id);
        }

        public void AtualizarSituacao(Situacao s)
        {
            RepSituacao rep = new RepSituacao();
            if (rep.FindById(s.IdSituacao) != null)
            {
                rep.UpdateAll(s);
            }

        }

        public void ExcluirSituacao(int situacao_id)
        {
            RepSituacao rep = new RepSituacao();

            if (rep.FindById(situacao_id) != null)
            {
                rep.Delete(situacao_id);
            }
        }
        #endregion

        //Tipo 

        #region Tipo
        public void InserirTipo(Tipo t)
        {
            RepTipo rep = new RepTipo();
            rep.Insert(t);
        }

        public List<Tipo> BuscarTodosTipo()
        {
            RepTipo rep = new RepTipo();
            return rep.FindAll();
        }

        public List<Tipo> ConsultarTipo(int sistema_id, int responsavel_id, int situacao_id)
        {
            RepTipo rep = new RepTipo();

            return rep.FindBySistResSit(sistema_id, responsavel_id, situacao_id);
        }

        public void AtualizarTipo(Tipo t)
        {
            RepTipo rep = new RepTipo();
            if (rep.FindById(t.IdTipo) != null)
            {
                rep.UpdateAll(t);
            }

        }

        public void ExcluirTipo(int tipo_id)
        {
            RepTipo rep = new RepTipo();

            if (rep.FindById(tipo_id) != null)
            {
                rep.Delete(tipo_id);
            }
        }
        #endregion

        //Retorno 

        #region Retorno
        public void InserirRetorno(Retorno r)
        {
            RepRetorno rep = new RepRetorno();
            rep.Insert(r);
        }

        public List<Retorno> BuscarTodosRetorno()
        {
            RepRetorno rep = new RepRetorno();
            return rep.FindAll();
        }

        public List<Retorno> ConsultarTipo(int sistema_id, int responsavel_id, int situacao_id, int tipo_id)
        {
            RepRetorno rep = new RepRetorno();

            return rep.FindBySistResSitTip(sistema_id, responsavel_id, situacao_id, tipo_id);
        }

        public void AtualizarRetorno(Retorno r)
        {
            RepRetorno rep = new RepRetorno();
            if (rep.FindById(r.IdRetorno) != null)
            {
                rep.UpdateAll(r);
            }

        }

        public void ExcluirRetorno(int retorno_id)
        {
            RepRetorno rep = new RepRetorno();

            if (rep.FindById(retorno_id) != null)
            {
                rep.Delete(retorno_id);
            }
        }
        #endregion
    }
}
