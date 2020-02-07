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
    public class RepSituacao : dbase
    {
        public void Insert(Situacao s)
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.situacao_tb (Situacao, Descricao, Dt_inclusao, usuario) "
                         + "VALUES(@Nome, @Descricao, @DtInclusao, @Usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@DtInclusao", s.DtInclusao);
            cmd.Parameters.AddWithValue("@Usuario", s.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public List<Situacao> FindAll()
        {
            abrir();

            string query = "SELECT DISTINCT situacao_id, Situacao, Descricao "
                         + "FROM desenv_db.dbo.situacao_tb";



            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Situacao> lista = new List<Situacao>();

            while (dr.Read())
            {
                Situacao s = new Situacao();

                s.IdSituacao = Convert.ToInt32(dr["situacao_id"]);
                s.Nome = Convert.ToString(dr["Situacao"]);
                s.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(s);
            }

            fechar();

            return lista;
        }

        public Situacao FindById(int situacao_id)
        {
            abrir();

            string query = "SELECT situacao_id, Situacao, Descricao "
                         + "FROM desenv_db.dbo.situacao_tb "
                         + "WHERE situacao_id = @situacao_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            dr = cmd.ExecuteReader();

            Situacao s = null;

            if (dr.Read())
            {
                s = new Situacao();

                s.IdSituacao = Convert.ToInt32(dr["situacao_id"]);
                s.Nome = Convert.ToString(dr["Situacao"]);
                s.Descricao = Convert.ToString(dr["Descricao"]);
            }

            fechar();

            return s;
        }

        public List<Situacao> FindBySistRes(int sistema_id, int responsavel_id)
        {
            abrir();

            string query = "SELECT DISTINCT a.situacao_id, situacao_tb.situacao "
                           + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb a WITH(NOLOCK) "
                           + "JOIN desenv_db.dbo.situacao_tb situacao_tb "
                           + "ON situacao_tb.situacao_id = a.situacao_id "
                           + "WHERE a.sistema_id = @sistema_id "
                           + "AND a.responsavel_id = @responsavel_id "
                           + "AND a.ativo = 's'";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            dr = cmd.ExecuteReader();

            List<Situacao> lista = new List<Situacao>();

            while (dr.Read())
            {
                Situacao s = new Situacao();

                s.IdSituacao = Convert.ToInt32(dr["situacao_id"]);
                s.Nome = Convert.ToString(dr["situacao"]);

                lista.Add(s);
            }

            fechar();

            return lista;
        }

        public void UpdateNome(int situacao_id, string nome)
        {
            abrir();

            string query = "UPDATE situacao_tb "
                         + "SET Situacao = @Nome "
                         + "FROM desenv_db.dbo.situacao_tb situacao_tb "
                         + "WHERE situacao_id = @situacao_id";

            Situacao s = new Situacao();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateDescricao(int situacao_id, string descricao)
        {
            abrir();

            string query = "UPDATE situacao_tb "
                         + "SET Descricao = @Descricao "
                         + "FROM desenv_db.dbo.situacao_tb situacao_tb "
                         + "WHERE situacao_id = @situacao_id";

            Situacao s = new Situacao();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateAll(Situacao s)
        {
            abrir();

            string query = "UPDATE situacao_tb "
                         + "SET Descricao = @Descricao "
                         + ", Situacao = @Nome"
                         + ", Dt_alteracao = @Dt_alteracao "
                         + ", Usuario = @Usuario "
                         + "FROM desenv_db.dbo.situacao_tb situacao_tb "
                         + "WHERE situacao_id = @situacao_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@situacao_id", s.IdSituacao);
            cmd.Parameters.AddWithValue("@Dt_alteracao", s.DtAlteracao);
            cmd.Parameters.AddWithValue("@Usuario", s.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int situacao_id)
        {
            abrir();

            string query = "DELETE FROM desenv_db.dbo.situacao_tb "
                         + "WHERE situacao_id = @situacao_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
