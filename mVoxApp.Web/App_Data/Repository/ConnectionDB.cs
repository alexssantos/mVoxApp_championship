using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mVoxApp.Web.App_Data.Repository
{
    public class ConnectionDB
    {
        #region DECLARAÇÕES Globais

        public  SqlConnection   obj_conexao = null;
        private SqlCommand      obj_comando = null;
        public  SqlDataReader   obj_DataReader = null;
        private SqlDataAdapter  obj_DataAdapter = null;
        private String          var_StrConexao = "";
        public  string          Error { get; set; }

        public  String          string_Conexao {

            get { return var_StrConexao; }
            set { var_StrConexao = value; }
        }
        #endregion
        
        #region METODOS INTERNOS
        //Obj_SqlConnection
        private void Pre_Conexao()
        {
            if (obj_conexao == null)
            {
                obj_conexao = new SqlConnection();
            }
        }
        //Command
        private void Criar_Comando(string query)
        {
            obj_comando = new SqlCommand();
            obj_comando.CommandType = CommandType.Text;
            obj_comando.CommandText = query;
            obj_comando.Connection = obj_conexao;
        }
        //DateReader
        private bool Criar_DataAdapter()
        {
            obj_DataAdapter = new SqlDataAdapter();
            return true;
        }

        #endregion

        //CONEXAO -----------------------
        public void Criar_Conexao()
        {
            Pre_Conexao();

            if (obj_conexao.State == ConnectionState.Broken || obj_conexao.State == ConnectionState.Closed)
            {
                obj_conexao.ConnectionString = var_StrConexao;
                obj_conexao.Open();
            }
        }
        public void Fechar_Conexao()
        {
            Pre_Conexao();

            if (obj_conexao.State == ConnectionState.Open)
            {
                //obj_conexao.ConnectionString = var_StrConexao;
                obj_conexao.Close();
            }
        }

        public bool ExecutarComando(string query, bool SELECT)
        {
            try
            {
                Criar_Comando(query);

                if (SELECT)
                {
                    obj_DataReader = obj_comando.ExecuteReader();
                    //se for um SELECT então realmente vai Ler e retornar true.
                    return true;
                }
                else
                {
                    // > 0 (Maior que zero) pq retorna o numero de linhas afetada. se não deletar, retorna FALSE.
                    return (obj_comando.ExecuteNonQuery() > 0);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
    }
}