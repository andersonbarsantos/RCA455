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
    public class RepRetorno : dbase
    {
        public void Insert(Retorno r)
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.RCA455_retorno_tb (Retorno, Descricao, Dt_inclusao, usuario) "
                         + "VALUES(@Nome, @Descricao, @DtInclusao, @Usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", r.Nome);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@DtInclusao", r.DtInclusao);
            cmd.Parameters.AddWithValue("@Usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public List<Retorno> FindAll()
        {
            abrir();

            string query = "SELECT retorno_id, Retorno, Descricao "
                         + "FROM desenv_db.dbo.RCA455_retorno_tb";



            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Retorno> lista = new List<Retorno>();

            while (dr.Read())
            {
                Retorno r = new Retorno();

                r.IdRetorno = Convert.ToInt32(dr["retorno_id"]);
                r.Nome = Convert.ToString(dr["Retorno"]);
                r.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public Retorno FindById(int retorno_id)
        {
            abrir();

            string query = "SELECT retorno_id, Retorno, Descricao "
                         + "FROM desenv_db.dbo.RCA455_retorno_tb "
                         + "WHERE retorno_id = @retorno_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@retorno_id", retorno_id);
            dr = cmd.ExecuteReader();

            Retorno r = null;

            if (dr.Read())
            {
                r = new Retorno();

                r.IdRetorno = Convert.ToInt32(dr["retorno_id"]);
                r.Nome = Convert.ToString(dr["Retorno"]);
                r.Descricao = Convert.ToString(dr["Descricao"]);
            }

            fechar();

            return r;
        }

        public List<Retorno> FindBySistResSitTip(int sistema_id, int responsavel_id, int situacao_id, int tipo_id)
        {
            abrir();

            string query = "SELECT DISTINCT a.retorno_id, RCA455_retorno_tb.retorno "
                           + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb a WITH(NOLOCK) "
                           + "JOIN desenv_db.dbo.RCA455_retorno_tb RCA455_retorno_tb "
                           + "ON RCA455_retorno_tb.retorno_id = a.retorno_id "
                           + "WHERE a.sistema_id = @sistema_id "
                           + "AND a.responsavel_id = @responsavel_id "
                           + "AND a.situacao_id = @situacao_id "
                           + "AND a.tipo_id = @tipo_id "
                           + "AND a.ativo = 's'";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            cmd.Parameters.AddWithValue("@tipo_id", tipo_id);
            dr = cmd.ExecuteReader();

            List<Retorno> lista = new List<Retorno>();

            while (dr.Read())
            {
                Retorno r = new Retorno();

                r.IdRetorno = Convert.ToInt32(dr["retorno_id"]);
                r.Nome = Convert.ToString(dr["retorno"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public void UpdateNome(int retorno_id, string nome)
        {
            abrir();

            string query = "UPDATE RCA455_retorno_tb "
                         + "SET Retorno = @Nome "
                         + "FROM desenv_db.dbo.RCA455_retorno_tb RCA455_retorno_tb "
                         + "WHERE retorno_id = @retorno_id";

            Tipo t = new Tipo();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@retorno_id", retorno_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateDescricao(int retorno_id, string descricao)
        {
            abrir();

            string query = "UPDATE RCA455_retorno_tb "
                         + "SET Descricao = @Descricao "
                         + "FROM desenv_db.dbo.RCA455_retorno_tb RCA455_retorno_tb "
                         + "WHERE retorno_id = @tipo_idretorno_id";

            Retorno r = new Retorno();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@retorno_id", retorno_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateAll(Retorno r)
        {
            abrir();

            string query = "UPDATE RCA455_retorno_tb "
                         + "SET Descricao = @Descricao "
                         + ", Retorno = @Nome"
                         + ", Dt_alteracao = @Dt_alteracao "
                         + ", Usuario = @Usuario "
                         + "FROM desenv_db.dbo.RCA455_retorno_tb RCA455_retorno_tb "
                         + "WHERE retorno_id = @retorno_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@Nome", r.Nome);
            cmd.Parameters.AddWithValue("@retorno_id", r.IdRetorno);
            cmd.Parameters.AddWithValue("@Dt_alteracao", r.DtAlteracao);
            cmd.Parameters.AddWithValue("@Usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int retorno_id)
        {
            abrir();

            string query = "DELETE FROM desenv_db.dbo.RCA455_retorno_tb "
                         + "WHERE retorno_id = @retorno_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@retorno_id", retorno_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
