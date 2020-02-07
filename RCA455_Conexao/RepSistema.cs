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
    public class RepSistema : dbase
    {
        public void Insert(Sistema s)
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.sistema_tb (Sistema, Descricao, Dt_inclusao, usuario) "
                         + "VALUES(@Nome, @Descricao, @DtInclusao, @Usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@DtInclusao", s.DtInclusao);
            cmd.Parameters.AddWithValue("@Usuario", s.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public List<Sistema> FindAll()
        {
            abrir();

            string query = "SELECT DISTINCT sistema_id, Sistema, Descricao "
                         + "FROM desenv_db.dbo.sistema_tb";



            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Sistema> lista = new List<Sistema>();

            while (dr.Read())
            {
                Sistema s = new Sistema();

                s.IdSistema = Convert.ToInt32(dr["sistema_id"]);
                s.Nome = Convert.ToString(dr["Sistema"]);
                s.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(s);
            }

            fechar();

                      return lista;
        }

        public Sistema FindById(int sistema_id)
        {
            abrir();

            string query = "SELECT sistema_id, Sistema, Descricao "
                         + "FROM desenv_db.dbo.sistema_tb "
                         + "WHERE sistema_id = @sistema_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            dr = cmd.ExecuteReader();

            Sistema s = null;

            if (dr.Read())
            {
                s = new Sistema();

                s.IdSistema = Convert.ToInt32(dr["sistema_id"]);
                s.Nome = Convert.ToString(dr["Sistema"]);
                s.Descricao = Convert.ToString(dr["Descricao"]);
            }

            fechar();

            return s;
        }

        public void UpdateNome(int sistema_id, string nome)
        {
            abrir();

            string query = "UPDATE sistema_tb "
                         + "SET Sistema = @Nome "
                         + "FROM desenv_db.dbo.sistema_tb sistema_tb "
                         + "WHERE sistema_id = @sistema_id";

            Sistema s = new Sistema();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateDescricao(int sistema_id, string descricao)
        {
            abrir();

            string query = "UPDATE sistema_tb "
                         + "SET Descricao = @Descricao "
                         + "FROM desenv_db.dbo.sistema_tb sistema_tb "
                         + "WHERE sistema_id = @sistema_id";

            Sistema s = new Sistema();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateAll(Sistema s)
        {
            abrir();

            string query = "UPDATE sistema_tb "
                         + "SET Descricao = @Descricao "
                         + ", Sistema = @Nome"
                         + ", Dt_alteracao = @Dt_alteracao "
                         + ", Usuario = @Usuario "
                         + "FROM desenv_db.dbo.sistema_tb sistema_tb "
                         + "WHERE sistema_id = @sistema_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", s.Descricao);
            cmd.Parameters.AddWithValue("@Nome", s.Nome);
            cmd.Parameters.AddWithValue("@sistema_id", s.IdSistema);
            cmd.Parameters.AddWithValue("@Dt_alteracao", s.DtAlteracao);
            cmd.Parameters.AddWithValue("@Usuario", s.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int sistema_id)
        {
            abrir();

            string query = "DELETE FROM desenv_db.dbo.sistema_tb "
                         + "WHERE sistema_id = @sistema_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
