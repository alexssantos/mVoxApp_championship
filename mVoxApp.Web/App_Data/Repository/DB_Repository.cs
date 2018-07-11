using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace mVoxApp.Web.App_Data.Repository
{
    public class DB_Repository
    {
        /// <summary>
        /// 1. Metodo Connect_BD
        /// 2. Metodo Insert_DB
        /// 3. Metodo Update_DB
        /// 4. Metodo Delete_DB
        /// 5. Metodo Get_DB
        /// 
        /// </summary>

        ConnectionDB conexao;

        public void Conectar()
        {
            conexao = new ConnectionDB();
            conexao.string_Conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\mVoxApp_Data.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Criar_Conexao();
        }

        #region CRUD TEAM

        //CREATE
        public bool CreateTeam_DB(TeamModel _team)
        {
            bool retorno = false;
            Conectar();
            try
            {
                using (conexao.obj_conexao = new SqlConnection(conexao.string_Conexao))
                {
                    conexao.obj_conexao.Open();
                    string query = "INSERT into Team " +
                      " (name , flag, keygroup) " +
                      " values " +
                      " ('{0}','{1}','{2}')";
                    query = string.Format(query, _team.Name,
                                                // _team.Flag,
                                                 _team.KeyGroup);
                    retorno = conexao.ExecutarComando(query, false);
                }
            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }
            return retorno;
        }

        //UPDATE
        public bool UpdateTeam_DB(TeamModel _team)
        {
            bool retorno = false;
            Conectar();
            try
            {
                using (conexao.obj_conexao = new SqlConnection(conexao.string_Conexao))
                {
                    conexao.obj_conexao.Open();
                    string query = @"update team set name = '{1}'
                                                 flag = '{2}',
                                                 keygroup = '{3}',                                      
                               where id = '{0}'";

                    query = string.Format(query, _team.Id,
                                                     _team.Name,
                                                    // _team.Flag,
                                                     _team.KeyGroup);

                    retorno = conexao.ExecutarComando(query, false);
                }
            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }
            return retorno;
        }

        //DELETE
        public bool DeleteTeam_DB(int id)
        {
            bool retorno = false;
            Conectar();
            try
            {
                using (conexao.obj_conexao = new SqlConnection(conexao.string_Conexao))
                {
                    conexao.obj_conexao.Open();
                    string query = "delete team where id = '{0}'";

                    query = string.Format(query, id);

                    //paramentro FALSE - pq não é um SELECT para retornar obj.
                    retorno = conexao.ExecutarComando(query, false);
                }
            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }

            return retorno;
        }

        //READ ------------------------------
        public List<TeamModel> GetTeams()
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<TeamModel> ListaRetorno;

            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();
                string query = "SELECT * FROM team";
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingTeams(conexao);
            }

            return ListaRetorno;
        }

        //---- BY ID
        public TeamModel GetTeamByID(int id)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<TeamModel> ListaRetorno;
            TeamModel _teamRetorno;
            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();

                string query = "select * from team where id = '{0}'";
                query = string.Format(query, id);
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingTeams(conexao);

                //Busca repetida

                if (ListaRetorno.Count > 1)
                {
                    _teamRetorno = ListaRetorno.Find(x => x.Id == id);
                }
                else
                {
                    _teamRetorno = ListaRetorno.First();
                }
            }


            //conexao.Fechar_Conexao();
            return _teamRetorno;
        }

        //---- BY NAME
        public List<TeamModel> GetTeamBySTRING(string busca)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<TeamModel> ListaRetorno;
            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();

                string query = "select * from team where name like '%{0}%' ";
                query = string.Format(query, busca);
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingTeams(conexao);
            }


            //conexao.Fechar_Conexao();
            return ListaRetorno;
        }

        //---- BY DATE
        public List<TeamModel> GetTeamByDATE(DateTime createdIn_Date)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<TeamModel> ListaRetorno;

            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();

                string query = $"SELECT * FROM team WHERE created = {createdIn_Date.DayOfYear}";
                query = string.Format(query, createdIn_Date);
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingTeams(conexao);

            }
            return ListaRetorno;
        }
        #endregion

        //TEAM Mapping
        private List<TeamModel> MappingTeams(ConnectionDB conexao)
        {
            List<TeamModel> ListaRetorno = new List<TeamModel>();
            TeamModel aux = null;

            if (conexao.obj_DataReader.HasRows)
            {
                while (conexao.obj_DataReader.Read())
                {
                    aux = new TeamModel();
                    aux.Id = (int)conexao.obj_DataReader["id"];
                    aux.Name = conexao.obj_DataReader["name"].ToString();
                    aux.KeyGroup = (int)conexao.obj_DataReader["keygroup"];
                    //aux.Flag = conexao.obj_DataReader["flag"].ToString();

                    ListaRetorno.Add(aux);
                }
            }
            return ListaRetorno;
        }

        //-----------------------KeyGorup ---------------------------

        public List<KeyGroupModel> GetKeyGroups()
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<KeyGroupModel> ListaRetorno;

            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();

                string query = "SELECT * FROM keygroup";
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingKeygroup(conexao);
            }
            return ListaRetorno;
        }

        public KeyGroupModel GetKeyGroupByID(int id)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            List<KeyGroupModel> ListaRetorno;
            KeyGroupModel _teamRetorno;
            using (conexao.obj_conexao = new System.Data.SqlClient.SqlConnection(conexao.string_Conexao))
            {
                conexao.obj_conexao.Open();

                string query = "select * from keygroup where id = '{0}'";
                query = string.Format(query, id);
                conexao.ExecutarComando(query, true);

                //MAPEAMENTO
                ListaRetorno = MappingKeygroup(conexao);

                //Busca repetida

                if (ListaRetorno.Count > 1)
                {
                    _teamRetorno = ListaRetorno.Find(x => x.Id == id);
                }
                else
                {
                    _teamRetorno = ListaRetorno.First();
                }
            }
            return _teamRetorno;
        }

        //Mapping KeyGroups
        private List<KeyGroupModel> MappingKeygroup(ConnectionDB conexao)
        {
            List<KeyGroupModel> ListaRetorno = new List<KeyGroupModel>();
            KeyGroupModel aux = null;

            if (conexao.obj_DataReader.HasRows)
            {
                while (conexao.obj_DataReader.Read())
                {
                    aux = new KeyGroupModel();
                    aux.Id = (int)conexao.obj_DataReader["id"];
                    aux.Name = conexao.obj_DataReader["name"].ToString();
                   // aux.maxTeams = (int)conexao.obj_DataReader["maxteams"];
                   // aux.totalTeams = (int)conexao.obj_DataReader["totalteams"];

                    ListaRetorno.Add(aux);
                }
            }
            return ListaRetorno;
        }

    }
}