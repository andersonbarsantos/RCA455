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
    public class RepTipo : dbase
    {
        public void Insert(Tipo t)
        {
            abrir();

            string query = "INSERT INTO desenv_db.dbo.tipo_tb (Tipo, Descricao, Dt_inclusao, usuario) "
                         + "VALUES(@Nome, @Descricao, @DtInclusao, @Usuario) ";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@DtInclusao", t.DtInclusao);
            cmd.Parameters.AddWithValue("@Usuario", t.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public List<Tipo> FindAll()
        {
            abrir();

            string query = "SELECT tipo_id, Tipo, Descricao "
                         + "FROM desenv_db.dbo.tipo_tb";



            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Tipo> lista = new List<Tipo>();

            while (dr.Read())
            {
                Tipo t = new Tipo();

                t.IdTipo = Convert.ToInt32(dr["tipo_id"]);
                t.Nome = Convert.ToString(dr["Tipo"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(t);
            }

            fechar();

            return lista;
        }

        public Tipo FindById(int tipo_id)
        {
            abrir();

            string query = "SELECT tipo_id, Tipo, Descricao "
                         + "FROM desenv_db.dbo.tipo_tb "
                         + "WHERE tipo_id = @tipo_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tipo_id", tipo_id);
            dr = cmd.ExecuteReader();

            Tipo t = null;

            if (dr.Read())
            {
                t = new Tipo();

                t.IdTipo = Convert.ToInt32(dr["tipo_id"]);
                t.Nome = Convert.ToString(dr["Tipo"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
            }

            fechar();

            return t;
        }

        public List<Tipo> FindBySistResSit(int sistema_id, int responsavel_id, int situacao_id)
        {
            abrir();

            string query = "SELECT DISTINCT a.tipo_id, tipo_tb.tipo "
                           + "FROM desenv_db.dbo.An_sustentacao_regra_RCA455_tb a WITH(NOLOCK) "
                           + "JOIN desenv_db.dbo.tipo_tb tipo_tb "
                           + "ON tipo_tb.tipo_id = a.tipo_id "
                           + "WHERE a.sistema_id = @sistema_id "
                           + "AND a.responsavel_id = @responsavel_id "
                           + "AND a.situacao_id = @situacao_id "
                           + "AND a.ativo = 's'"; 

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sistema_id", sistema_id);
            cmd.Parameters.AddWithValue("@responsavel_id", responsavel_id);
            cmd.Parameters.AddWithValue("@situacao_id", situacao_id);
            dr = cmd.ExecuteReader();

            List<Tipo> lista = new List<Tipo>();

            while (dr.Read())
            {
                Tipo t = new Tipo();

                t.IdTipo = Convert.ToInt32(dr["tipo_id"]);
                t.Nome = Convert.ToString(dr["tipo"]);

                lista.Add(t);
            }

            fechar();

            return lista;
        }

        public void UpdateNome(int tipo_id, string nome)
        {
            abrir();

            string query = "UPDATE tipo_tb "
                         + "SET Tipo = @Nome "
                         + "FROM desenv_db.dbo.tipo_tb tipo_tb "
                         + "WHERE tipo_id = @tipo_id";

            Tipo t = new Tipo();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@tipo_id", tipo_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateDescricao(int tipo_id, string descricao)
        {
            abrir();

            string query = "UPDATE tipo_tb "
                         + "SET Descricao = @Descricao "
                         + "FROM desenv_db.dbo.tipo_tb tipo_tb "
                         + "WHERE tipo_id = @tipo_id";

            Tipo t = new Tipo();

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@tipo_id", tipo_id);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void UpdateAll(Tipo t)
        {
            abrir();

            string query = "UPDATE tipo_tb "
                         + "SET Descricao = @Descricao "
                         + ", Tipo = @Nome"
                         + ", Dt_alteracao = @Dt_alteracao "
                         + ", Usuario = @Usuario "
                         + "FROM desenv_db.dbo.tipo_tb tipo_tb "
                         + "WHERE tipo_id = @tipo_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@tipo_id", t.IdTipo);
            cmd.Parameters.AddWithValue("@Dt_alteracao", t.DtAlteracao);
            cmd.Parameters.AddWithValue("@Usuario", t.Usuario);
            cmd.ExecuteNonQuery();

            fechar();
        }

        public void Delete(int tipo_id)
        {
            abrir();

            string query = "DELETE FROM desenv_db.dbo.tipo_tb "
                         + "WHERE tipo_id = @tipo_id";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tipo_id", tipo_id);
            cmd.ExecuteNonQuery();

            fechar();
        }
    }
}
