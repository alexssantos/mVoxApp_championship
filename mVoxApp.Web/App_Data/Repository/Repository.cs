using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mVoxApp.Web.App_Data.Repository
{
    public class Repository
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
        public bool Create_DB(Team _team)
        {
            bool retorno = false;
            try
            {
                Conectar();
                string query = "INSERT into Team " +
                       " (name , flag, keygroup) " +
                       " values " +
                       " ('{0}','{1}','{2}')";
                query = string.Format(query, _team.name,
                                             _team.flag,
                                             _team.keyGroup);
                retorno = conexao.ExecutarComando(query, false);
                //conexao.Fechar_Conexao();
            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }

            return retorno;
        }

        //UPDATE
        public bool Update_DB(Team _team)
        {
            bool retorno = false;
            try
            {
                Conectar();

                string query = @"update team set name = '{1}'
                                                 flag = '{2}',
                                                 keygroup = '{3}',                                      
                               where id = '{0}'";

                query = string.Format(query, _team.id,
                                                 _team.name,
                                                 _team.flag,
                                                 _team.keyGroup);

                retorno = conexao.ExecutarComando(query, false);
                //conexao.Fechar_Conexao();
            }
            catch (Exception ex)
            {

                conexao.Error = ex.Message;
            }
            return retorno;
        }

        //DELETE
        public bool Delete_DB(int id)
        {
            bool retorno = false;

            try
            {
                Conectar();

                string query = "delete team where id = '{0}'";

                query = string.Format(query, id);

                //paramentro FALSE - pq não é um SELECT para retornar obj.
                retorno = conexao.ExecutarComando(query, false);
                //conexao.Fechar_Conexao();
            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }

            return retorno;
        }
        
        //READ ------------------------------
        public List<Team> GetTeams()
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "SELECT * FROM team";
            conexao.ExecutarComando(query, true);

            //MAPEAMENTO
            List<Team> ListaRetorno = MappingTeams(conexao);

            //conexao.Fechar_Conexao();
            return ListaRetorno;
        }
        //---- BY ID
        public Team GetByID(int id)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "select * from team where id = '{0}'";
            query = string.Format(query, id);
            conexao.ExecutarComando(query, true);
            
            //MAPEAMENTO
            List<Team> ListaRetorno = MappingTeams(conexao);
                        
            //Busca repetida
            Team _teamRetorno;
            if (ListaRetorno.Count > 1)
            {
               _teamRetorno = ListaRetorno.Find(x => x.id == id);
            }
            else
            {
               _teamRetorno = ListaRetorno.First();
            }

            //conexao.Fechar_Conexao();
            return _teamRetorno;
        } 
        //---- BY NAME
        public List<Team> GetBySTRING(string busca)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "select * from team where name like '%{0}%' ";
            query = string.Format(query, busca);
            conexao.ExecutarComando(query, true);

            //MAPEAMENTO
            List<Team> ListaRetorno = MappingTeams(conexao);

            //conexao.Fechar_Conexao();
            return ListaRetorno;
        } 
        //---- BY DATE
        public List<Team> DetByDATE(DateTime createdIn_Date)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = $"SELECT * FROM team WHERE created = {createdIn_Date.DayOfYear}";
            query = string.Format(query, createdIn_Date);
            conexao.ExecutarComando(query, true);

            //MAPEAMENTO
            List<Team> ListaRetorno = MappingTeams(conexao);

            //conexao.Fechar_Conexao();
            return ListaRetorno;
        }

        #endregion

        //Mapping TEAM
        private List<Team> MappingTeams(ConnectionDB conexao)
        {
            List<Team> ListaRetorno = new List<Team>();
            Team aux = null;

            if (conexao.obj_DataReader.HasRows)
            {
                while (conexao.obj_DataReader.Read())
                {
                    aux = new Team();
                    aux.id = (int)conexao.obj_DataReader["id"];
                    aux.name = conexao.obj_DataReader["name"].ToString();
                    aux.keyGroup = (int)conexao.obj_DataReader["keygroup"];
                    aux.flag = conexao.obj_DataReader["flag"].ToString();

                    ListaRetorno.Add(aux);
                }
            }
            return ListaRetorno;
        }

        //-----------------------KeyGorup ---------------------------

        public List<KeyGroup> GetKeyGroups()
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "SELECT * FROM keygroup";
            conexao.ExecutarComando(query, true);

            //MAPEAMENTO
            List<KeyGroup> ListaRetorno = MappingKeygroup(conexao);

            //conexao.Fechar_Conexao();
            return ListaRetorno;
        }

        public KeyGroup GetKeyGroupByID(int id)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "select * from keygroup where id = '{0}'";
            query = string.Format(query, id);
            conexao.ExecutarComando(query, true);

            //MAPEAMENTO
            List<KeyGroup> ListaRetorno = MappingKeygroup(conexao);

            //Busca repetida
            KeyGroup _teamRetorno;
            if (ListaRetorno.Count > 1)
            {
                _teamRetorno = ListaRetorno.Find(x => x.id == id);
            }
            else
            {
                _teamRetorno = ListaRetorno.First();
            }

            //conexao.Fechar_Conexao();
            return _teamRetorno;
        }

        //Mapping TEAM
        private List<KeyGroup> MappingKeygroup(ConnectionDB conexao)
        {
            List<KeyGroup> ListaRetorno = new List<KeyGroup>();
            KeyGroup aux = null;

            if (conexao.obj_DataReader.HasRows)
            {
                while (conexao.obj_DataReader.Read())
                {
                    aux = new KeyGroup();
                    aux.id = (int)conexao.obj_DataReader["id"];
                    aux.name = conexao.obj_DataReader["name"].ToString();
                    aux.maxTeams = (int)conexao.obj_DataReader["maxteams"];
                    aux.totalTeams = (int)conexao.obj_DataReader["totalteams"];                    

                    ListaRetorno.Add(aux);
                }
            }
            return ListaRetorno;
        }
    }
}