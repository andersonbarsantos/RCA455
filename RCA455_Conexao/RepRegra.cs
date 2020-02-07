using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RCA455_Conexao
{
    public class RepRegra : dbase
    {
        public List<Regra> Find()
        {
            abrir();

            string query = "SELECT distinct descricao, "
                           + "COUNT(*) AS quantidade "
                           + "FROM desenv_db.dbo.An_sustentacao_geral_teste_RCA455_tb WITH(NOLOCK) "
                           + "GROUP BY descricao "
                           + "ORDER BY quantidade DESC";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Regra> lista = new List<Regra>();

            while (dr.Read())
            {
                Regra r = new Regra();

                r.Descricao = Convert.ToString(dr["descricao"]);
                r.Quantidade = Convert.ToInt32(dr["quantidade"]);

                lista.Add(r);

            }

            fechar();

            return lista;

        }

        public List<Regra> FindAll()
        {
            abrir();

            string query = "SELECT a.*, sistema, responsavel, situacao, tipo, retorno "
                         + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb a WITH(NOLOCK) "
                         + "LEFT JOIN desenv_db.dbo.sistema_tb sistema_tb WITH(NOLOCK) "
                         + "ON sistema_tb.sistema_id = a.sistema_id "
                         + "LEFT JOIN desenv_db.dbo.responsavel_tb responsavel_tb WITH(NOLOCK) "
                         + "ON responsavel_tb.responsavel_id = a.responsavel_id "
                         + "LEFT JOIN desenv_db.dbo.situacao_tb situacao_tb WITH(NOLOCK) "
                         + "ON situacao_tb.situacao_id = a.situacao_id "
                         + "LEFT JOIN desenv_db.dbo.tipo_tb tipo_tb WITH(NOLOCK) "
                         + "ON tipo_tb.tipo_id = a.tipo_id "
                         + "LEFT JOIN desenv_db.dbo.RCA455_retorno_tb retorno_tb WITH(NOLOCK) "
                         + "ON retorno_tb.retorno_id = a.retorno_id";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Regra> lista = new List<Regra>();

            while (dr.Read())
            {
                Regra r = new Regra();
                r.Sistema = new Sistema();
                r.Responsavel = new Responsavel();
                r.Situacao = new Situacao();
                r.Tipo = new Tipo();
                r.Retorno = new Retorno();

                r.Id_regra = Convert.ToInt32(dr["an_sustentacao_regra_tb_id"]);
                r.Sistema.Nome = Convert.ToString(dr["sistema"]);
                r.Responsavel.Nome = Convert.ToString(dr["responsavel"]);
                r.Situacao.Nome = Convert.ToString(dr["situacao"]);
                r.Tipo.Nome = Convert.ToString(dr["tipo"]);
                r.Retorno.Nome = Convert.ToString(dr["retorno"]);
                r.Ativo = Convert.ToString(dr["ativo"]);
                r.Descricao = Convert.ToString(dr["descricao"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public List<Regra> FindNull()
        {
            abrir();


            string query = "SELECT DISTINCT an_sustentacao_geral_id, sistema, responsavel, situacao, tipo, retorno, a.descricao, COUNT(*) as quantidade "
                         + "FROM desenv_db.dbo.An_sustentacao_geral_teste_RCA455_tb a WITH(NOLOCK) "
                         + "LEFT JOIN desenv_db.dbo.sistema_tb sistema_tb WITH(NOLOCK) "
                         + "ON sistema_tb.sistema_id = a.sistema_id "
                         + "LEFT JOIN desenv_db.dbo.responsavel_tb responsavel_tb WITH(NOLOCK) "
                         + "ON responsavel_tb.responsavel_id = a.responsavel_id "
                         + "LEFT JOIN desenv_db.dbo.situacao_tb situacao_tb WITH(NOLOCK) "
                         + "ON situacao_tb.situacao_id = a.situacao_id "
                         + "LEFT JOIN desenv_db.dbo.tipo_tb tipo_tb WITH(NOLOCK) "
                         + "ON tipo_tb.tipo_id = a.tipo_id "
                         + "LEFT JOIN desenv_db.dbo.RCA455_retorno_tb retorno_tb WITH(NOLOCK) "
                         + "ON retorno_tb.retorno_id = a.retorno_id "
                         + "WHERE a.sistema_id IS NULL "
                         + "GROUP BY an_sustentacao_geral_id, sistema, responsavel, situacao, tipo, retorno, a.descricao";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Regra> lista = new List<Regra>();

            while (dr.Read())
            {
                Regra r = new Regra();
                r.Sistema = new Sistema();
                r.Responsavel = new Responsavel();
                r.Situacao = new Situacao();
                r.Tipo = new Tipo();
                r.Retorno = new Retorno();

                r.Id_regra = Convert.ToInt32(dr["an_sustentacao_geral_id"]);
                r.Sistema.Nome = Convert.ToString(dr["sistema"]);
                r.Responsavel.Nome = Convert.ToString(dr["responsavel"]);
                r.Situacao.Nome = Convert.ToString(dr["situacao"]);
                r.Tipo.Nome = Convert.ToString(dr["tipo"]);
                r.Retorno.Nome = Convert.ToString(dr["retorno"]);
                r.Descricao = Convert.ToString(dr["descricao"]);
                r.Quantidade = Convert.ToInt32(dr["quantidade"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public List<Regra> FindNotNull()
        {
            abrir();


            string query = "SELECT DISTINCT an_sustentacao_geral_id, sistema, responsavel, situacao, tipo, retorno, a.descricao, COUNT(*) as quantidade "
                         + "FROM desenv_db.dbo.An_sustentacao_geral_teste_RCA455_tb a WITH(NOLOCK) "
                         + "LEFT JOIN desenv_db.dbo.sistema_tb sistema_tb WITH(NOLOCK) "
                         + "ON sistema_tb.sistema_id = a.sistema_id "
                         + "LEFT JOIN desenv_db.dbo.responsavel_tb responsavel_tb WITH(NOLOCK) "
                         + "ON responsavel_tb.responsavel_id = a.responsavel_id "
                         + "LEFT JOIN desenv_db.dbo.situacao_tb situacao_tb WITH(NOLOCK) "
                         + "ON situacao_tb.situacao_id = a.situacao_id "
                         + "LEFT JOIN desenv_db.dbo.tipo_tb tipo_tb WITH(NOLOCK) "
                         + "ON tipo_tb.tipo_id = a.tipo_id "
                         + "LEFT JOIN desenv_db.dbo.RCA455_retorno_tb retorno_tb WITH(NOLOCK) "
                         + "ON retorno_tb.retorno_id = a.retorno_id "
                         + "WHERE a.sistema_id IS NOT NULL "
                         + "GROUP BY an_sustentacao_geral_id, sistema, responsavel, situacao, tipo, retorno, a.descricao";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Regra> lista = new List<Regra>();

            while (dr.Read())
            {
                Regra r = new Regra();
                r.Sistema = new Sistema();
                r.Responsavel = new Responsavel();
                r.Situacao = new Situacao();
                r.Tipo = new Tipo();
                r.Retorno = new Retorno();

                r.Id_regra = Convert.ToInt32(dr["an_sustentacao_geral_id"]);
                r.Sistema.Nome = Convert.ToString(dr["sistema"]);
                r.Responsavel.Nome = Convert.ToString(dr["responsavel"]);
                r.Situacao.Nome = Convert.ToString(dr["situacao"]);
                r.Tipo.Nome = Convert.ToString(dr["tipo"]);
                r.Retorno.Nome = Convert.ToString(dr["retorno"]);
                r.Descricao = Convert.ToString(dr["descricao"]);
                r.Quantidade = Convert.ToInt32(dr["quantidade"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public Regra FindById(int regra_id)
        {
            abrir();

            string query = "SELECT an_sustentacao_regra_tb_id "
                           + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb WITH(NOLOCK) "
                           + "WHERE an_sustentacao_regra_tb_id = @regra_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@regra_id", regra_id);
            dr = cmd.ExecuteReader();

            Regra r = null;

            while (dr.Read())
            {
                r = new Regra();

                r.Id_regra = Convert.ToInt32(dr["an_sustentacao_regra_tb_id"]);
            }

            fechar();

            return r;
        }


        public void Insert(Regra r)
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.An_sustentacao_regra_RCA455_tb(responsavel_id, sistema_id, situacao_id, tipo_id, retorno_id, descricao "
                         + ", dt_inicio_vigencia, ativo, dt_inclusao, usuario) "
                         + "VALUES (@responsavel_id, @sistema_id, @situacao_id, @tipo_id, @retorno_id, @descricao, @dt_inicio_vigencia "
                         + ", @ativo, @dt_inclusao, @usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@responsavel_id", r.Responsavel.IdResponsavel);
            cmd.Parameters.AddWithValue("@sistema_id", r.Sistema.IdSistema);
            cmd.Parameters.AddWithValue("@situacao_id", r.Situacao.IdSituacao);
            cmd.Parameters.AddWithValue("@tipo_id", r.Tipo.IdTipo);
            cmd.Parameters.AddWithValue("@retorno_id", r.Retorno.IdRetorno);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@dt_inicio_vigencia", r.DtInicioVigencia);
            cmd.Parameters.AddWithValue("@ativo", r.Ativo);
            cmd.Parameters.AddWithValue("@dt_inclusao", r.DtInclusao);
            cmd.Parameters.AddWithValue("@usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Update(Regra r) 
        {
            abrir();

            string query = "UPDATE a "
                         + "SET a.sistema_id = @sistema_id "
                         + ", a.responsavel_id = @responsavel_id "
                         + ", a.situacao_id = @situacao_id "
                         + ", a.tipo_id = @tipo_id "
                         + ", a.retorno_id = @retorno_id "
                         + ", dt_alteracao = @dt_alteracao "
                         + ", usuario = usuario "
                         + "FROM desenv_db.dbo.An_sustentacao_geral_teste_RCA455_tb a "
                         + "WHERE a.an_sustentacao_geral_id = @an_sustentacao_geral_id";

            //r.Sistema = new Sistema();
            //r.Responsavel = new Responsavel();
            //r.Situacao = new Situacao();
            //r.Tipo = new Tipo();
            //r.Retorno = new Retorno();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@an_sustentacao_geral_id", r.Id_regra);
            cmd.Parameters.AddWithValue("@sistema_id", r.Sistema.IdSistema);
            cmd.Parameters.AddWithValue("@responsavel_id", r.Responsavel.IdResponsavel);
            cmd.Parameters.AddWithValue("@situacao_id", r.Situacao.IdSituacao);
            cmd.Parameters.AddWithValue("@tipo_id", r.Tipo.IdTipo);
            cmd.Parameters.AddWithValue("@retorno_id", r.Retorno.IdRetorno);
            cmd.Parameters.AddWithValue("@dt_alteracao", r.DtAlteracao);
            cmd.Parameters.AddWithValue("@usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int regra_id)
        {
            abrir();

            string query = "DELETE FROM An_sustentacao_regra_RCA455_tb WHERE an_sustentacao_regra_tb_id = @regra_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@regra_id", regra_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
