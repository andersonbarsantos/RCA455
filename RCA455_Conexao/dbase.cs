using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RCA455_Conexao
{
    public class dbase
    {
        #region Propriedades
        private bool tr = false;
        protected SqlConnection con;
        protected SqlConnection ConTrans;
        protected SqlCommand cmd;
        protected DataTable dt;
        protected SqlDataReader dr;
        SqlTransaction st;
        //private DataSet ds;
        //private SqlDataAdapter da;
        private string ambiente_;
        #endregion

        #region Construtor

        public dbase()
        {

            string ambiente = "Preprod" ;
            //ambiente = (String.IsNullOrEmpty(ambiente) ? "Produção" : ambiente);

            //Alianca.Seguranca.BancoDados.cCon conn = new Alianca.Seguranca.BancoDados.cCon();
            //bool b = conn.configurado;
            //Alianca.Seguranca.BancoDados.cCon.Ambientes amb;
            //if (ambiente.Substring(0, 1) == "Q")
            //    amb = Alianca.Seguranca.BancoDados.cCon.Ambientes.Qualidade;
            //else
            //    amb = Alianca.Seguranca.BancoDados.cCon.Ambientes.Produção;
            //Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //conn.ConfiguraConexao(assembly, amb);
            //b = conn.configurado;
            //conn.BancodeDados = "controle_servico_db";
            //string strcon = conn.ConnectionString;

            ambiente_ = ambiente;

            bool trans = false;

            if (trans)
            {
                tr = trans;
                ConTrans = new SqlConnection(ConfigurationManager.ConnectionStrings[ambiente].ToString());
                ConTrans.Open();
                st = ConTrans.BeginTransaction();
                //st.Connection.Open();
            }
            else
            {
                con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[ambiente].ToString();
            }

        }

        public dbase(string ambiente, bool trans = false)
        {
            ambiente = (String.IsNullOrEmpty(ambiente) ? "Preprod" : ambiente);
            //ambiente = (String.IsNullOrEmpty(ambiente) ? "Produção" : ambiente);

            //Alianca.Seguranca.BancoDados.cCon conn = new Alianca.Seguranca.BancoDados.cCon();
            //bool b = conn.configurado;
            //Alianca.Seguranca.BancoDados.cCon.Ambientes amb;
            //if (ambiente.Substring(0, 1) == "Q")
            //    amb = Alianca.Seguranca.BancoDados.cCon.Ambientes.Qualidade;
            //else
            //    amb = Alianca.Seguranca.BancoDados.cCon.Ambientes.Produção;
            //Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //conn.ConfiguraConexao(assembly, amb);
            //b = conn.configurado;
            //conn.BancodeDados = "controle_servico_db";
            //string strcon = conn.ConnectionString;

            ambiente_ = ambiente;


            if (trans)
            {
                tr = trans;
                ConTrans = new SqlConnection(ConfigurationManager.ConnectionStrings[ambiente].ToString());
                ConTrans.Open();
                st = ConTrans.BeginTransaction();
                //st.Connection.Open();
            }
            else
            {
                con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[ambiente].ToString();
            }
        }
        #endregion

        #region Funções
        protected void abrir()
        {
            if (tr)
            {
                if (st.Connection.State == ConnectionState.Closed)
                {
                    throw new Exception("Erro na conexao");
                }
            }
            else
            {
                if (con == null)
                {
                    con = new SqlConnection();
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings[ambiente_].ToString(); con.Open();
                }
            }
        }

        protected void fechar() { if (con.State == ConnectionState.Open) con.Close(); con.Dispose(); }
        protected void populaParametros(SqlCommand cmd, object model)
        {

            foreach (PropertyInfo p in model.GetType().GetProperties())
            {
                if (Convert.ToString(p.PropertyType).Contains("Int32"))
                {
                    if (Convert.ToInt32(p.GetValue(model, null).ToString()) > 0)
                    {
                        cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(model, null)).SqlDbType = SqlDbType.Int;
                    }
                }
                if (Convert.ToString(p.PropertyType).Contains("String"))
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(p.GetValue(model, null))))
                    {
                        cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(model, null)).SqlDbType = SqlDbType.VarChar;
                    }
                }
                if (Convert.ToString(p.PropertyType).Contains("DateTime"))
                {
                    if (Convert.ToDateTime(p.GetValue(model, null).ToString()) > DateTime.MinValue)
                    {
                        cmd.Parameters.AddWithValue("@" + p.Name, Convert.ToDateTime(p.GetValue(model, null)).ToString("yyyy/MM/dd HH:mm:ss"));
                    }
                }
                if (Convert.ToString(p.PropertyType).Contains("char"))
                {
                    if ((Convert.ToChar(p.GetValue(model, null)).ToString().Length) > 0)
                    {
                        cmd.Parameters.AddWithValue("@" + p.Name, p.GetValue(model, null)).SqlDbType = SqlDbType.Char;
                    }
                }
            }
        }
        public string getAmbiente()
        {
            return this.ambiente_;
        }
        #endregion

        #region Métodos
        public void Comitar() { st.Commit(); st.Dispose(); }
        public void Roll() { st.Rollback(); }
        public void KillTrans() { if (st.Connection != null) { if (st.Connection.State == ConnectionState.Open) { st.Connection.Close(); st.Connection.Dispose(); ConTrans.Close(); ConTrans.Dispose(); } } ConTrans.Close(); ConTrans.Dispose(); }
        public DataTable QueryDataTable(object model, string procName)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(procName, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.Connection = ConTrans; cmd.CommandText = procName; }
            populaParametros(cmd, model);
            dt = new DataTable();
            try
            {
                if (!tr) abrir();
                dt.Load(cmd.ExecuteReader());
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return dt;
        }

        public DataTable QueryDataTable(SqlParameter[] parms, string procName)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(procName, con));
            if (tr) { cmd.Transaction = st; cmd.CommandText = procName; cmd.Connection = ConTrans; }
            cmd.CommandType = CommandType.StoredProcedure;
            //if (tr) { cmd.Transaction = st; cmd.Connection = ConTrans; cmd.CommandText = procName; }
            cmd.Parameters.AddRange(parms);
            dt = new DataTable();
            try
            {
                if (!tr) abrir();
                dt.Load(cmd.ExecuteReader());
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return dt;
        }

        public DataTable QueryDataTable(string comand)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            dt = new DataTable();
            try
            {
                if (!tr) abrir();
                dt.Load(cmd.ExecuteReader());
                if (!tr) { fechar(); }
            }
            catch (Exception e)
            {
                if (!tr) { fechar(); }
                throw e;
            }
            finally { if (!tr) { fechar(); } }
            return dt;
        }

        public string QueryString(string comand)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            string str = "";
            try
            {
                if (!tr) abrir();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                str = reader.GetString(0);
                if (!tr) { fechar(); }
            }
            catch (Exception e)
            {
                if (!tr) { fechar(); }
                throw e;
            }
            finally { if (!tr) { fechar(); } }
            return str;
        }

        public IDataReader Reader(string comand)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            IDataReader retorno;
            try
            {
                if (!tr) abrir();
                retorno = cmd.ExecuteReader();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno;
        }
        public bool ExecuteNowQuery(object model, string procName)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(procName, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.CommandText = procName; cmd.Connection = ConTrans; }
            populaParametros(cmd, model);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteNonQuery();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno > 0;
        }
        public int ExecuteNowQuery(object model, string procName, char nada)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(procName, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.CommandText = procName; cmd.Connection = ConTrans; }
            populaParametros(cmd, model);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteNonQuery();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno;
        }
        public bool ExecuteNowQuery(string comand)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteNonQuery();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno > 0;
        }
        public bool ExecuteNowQuery(string comand, object model)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            populaParametros(cmd, model);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteNonQuery();
                if (!tr) { fechar(); }
            }
            catch (Exception ex) { throw ex; }
            finally { if (!tr) { fechar(); } }
            return retorno > 0;
        }
        public bool ExecuteNowQuery(SqlParameter[] parms, string proc)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(proc, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.CommandText = proc; cmd.Connection = ConTrans; }
            cmd.Parameters.AddRange(parms);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteNonQuery();
                if (!tr) { fechar(); }
            }
            catch (Exception ex) { throw ex; }
            finally { if (!tr) { fechar(); } }
            return retorno > 0;
        }
        public bool ExecuteExcalar(string proc, object model)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(proc, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.CommandText = proc; cmd.Connection = ConTrans; }
            populaParametros(cmd, model);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteScalar();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno > 0;
        }
        public int ExecuteExcalar(object model, string proc)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(proc, con));
            cmd.CommandType = CommandType.StoredProcedure;
            if (tr) { cmd.Transaction = st; cmd.CommandText = proc; cmd.Connection = ConTrans; }
            populaParametros(cmd, model);
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                retorno = (int)cmd.ExecuteScalar();
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno;
        }
        public int ExecuteExcalar(string comand)
        {
            cmd = ((tr) ? new SqlCommand() : new SqlCommand(comand, con));
            cmd.CommandType = CommandType.Text;
            if (tr) { cmd.Transaction = st; cmd.CommandText = comand; cmd.Connection = ConTrans; }
            int retorno = 0;
            try
            {
                if (!tr) abrir();
                try { retorno = (int)cmd.ExecuteScalar(); }
                catch (NullReferenceException) { retorno = -1; };
                if (!tr) { fechar(); }
            }
            catch (Exception e) { throw e; }
            finally { if (!tr) { fechar(); } }
            return retorno;
        }
        #endregion
    }
}
