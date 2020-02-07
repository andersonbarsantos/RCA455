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
    public class RepResponsavel : dbase
    {
        public void Insert(Responsavel r) 
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.responsavel_tb (Responsavel, Descricao, Dt_inclusao, usuario) "
                         + "VALUES(@Nome, @Descricao, @DtInclusao, @Usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", r.Nome);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@DtInclusao", r.DtInclusao);
            cmd.Parameters.AddWithValue("@Usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public List<Responsavel> FindAll()
        {
            abrir();

            string query = "SELECT responsavel_id, Responsavel, Descricao "
                         + "FROM desenv_db.dbo.responsavel_tb";

            

            cmd = new SqlCommand(query, con);            
            dr = cmd.ExecuteReader();

            List<Responsavel> lista = new List<Responsavel>();

            while (dr.Read()) 
            {
                Responsavel r = new Responsavel();

                r.IdResponsavel = Convert.ToInt32(dr["responsavel_id"]);
                r.Nome = Convert.ToString(dr["Responsavel"]);
                r.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public Responsavel FindById(int responsavel_id)
        {
            abrir();

            string query = "SELECT responsavel_id, Responsavel, Descricao "
                         + "FROM desenv_db.dbo.responsavel_tb "
                         + "WHERE responsavel_id = @responsavel_id";
            
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            dr = cmd.ExecuteReader();

            Responsavel r = null;

            if (dr.Read())
            {
                r = new Responsavel();

                r.IdResponsavel = Convert.ToInt32(dr["responsavel_id"]);
                r.Nome = Convert.ToString(dr["Responsavel"]);
                r.Descricao = Convert.ToString(dr["Descricao"]);
            }

            fechar();

            return r;
        }

        public List<Responsavel> FindBySist(int sistema_id)
        {
            abrir();

            string query = "SELECT DISTINCT a.responsavel_id, responsavel_tb.responsavel "
                           + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb a WITH(NOLOCK) "
                           + "JOIN desenv_db.dbo.responsavel_tb responsavel_tb "
                           + "ON responsavel_tb.responsavel_id = a.responsavel_id "
                           + "WHERE a.sistema_id = @sistema_id "
                           + "AND a.ativo = 's'";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            dr = cmd.ExecuteReader();

            List<Responsavel> lista = new List<Responsavel>();

            while (dr.Read())
            {
                Responsavel r = new Responsavel();

                r.IdResponsavel = Convert.ToInt32(dr["responsavel_id"]);
                r.Nome = Convert.ToString(dr["responsavel"]);

                lista.Add(r);
            }

            fechar();

            return lista;
        }

        public void UpdateNome(int responsavel_id, string nome)
        {
            abrir();

            string query = "UPDATE responsavel_tb "
                         + "SET Responsavel = @Nome "
                         + "FROM desenv_db.dbo.responsavel_tb responsavel_tb "
                         + "WHERE responsavel_id = @responsavel_id";

            Responsavel r = new Responsavel();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", r.Nome);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateDescricao(int responsavel_id, string descricao)
        {
            abrir();

            string query = "UPDATE responsavel_tb "
                         + "SET Descricao = @Descricao "
                         + "FROM desenv_db.dbo.responsavel_tb responsavel_tb "
                         + "WHERE responsavel_id = @responsavel_id";

            Responsavel r = new Responsavel();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateAll(Responsavel r)
        {
            abrir();

            string query = "UPDATE responsavel_tb "
                         + "SET Descricao = @Descricao "
                         + ", Responsavel = @Nome"
                         + ", Dt_alteracao = @Dt_alteracao "
                         + ", Usuario = @Usuario "
                         + "FROM desenv_db.dbo.responsavel_tb responsavel_tb "
                         + "WHERE responsavel_id = @responsavel_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@Nome", r.Nome);
            cmd.Parameters.AddWithValue("@responsavel_id", r.IdResponsavel);
            cmd.Parameters.AddWithValue("@Dt_alteracao", r.DtAlteracao);
            cmd.Parameters.AddWithValue("@Usuario", r.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int responsavel_id)
        {
            abrir();

            string query = "DELETE FROM desenv_db.dbo.responsavel_tb "
                         + "WHERE responsavel_id = @responsavel_id";

            Responsavel r = new Responsavel();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
