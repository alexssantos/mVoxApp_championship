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


        public List<Team> GetTeams()
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "SELECT * FROM team";
            conexao.ExecutarComando(query, true);
            
            //MAPEAMENTO
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

        #region CRUD
        public bool AdicionarUsuario(Team _user)
        {
            bool retorno = false;

            try
            {
                Conectar();

                string query = "insert into amigos " +
                       " (nome,sobrenome,dataniver) " +
                       " values " +
                       " ('{0}','{1}','{2}')";

                query = string.Format(query, _user.name,
                                             _user.keyGroup,
                                             _user.points);

                retorno = conexao.ExecutarComando(query, false);

            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }

            return retorno;
        }

        //DELETE
        public bool Delete_Usuario(int id)
        {
            bool retorno = false;

            try
            {
                Conectar();

                string query = "delete amigos where id = '{0}'";

                query = string.Format(query, id);

                //paramentro FALSE pq não é um SELECT para retornar obj.
                retorno = conexao.ExecutarComando(query, false);

            }
            catch (Exception ex)
            {
                conexao.Error = ex.Message;
            }

            return retorno;
        }

        //UPDATE
        public bool update_usuario(Team _user)
        {
            bool retorno = false;

            try
            {
                Conectar();

                string query = @"update amigos set
                                     nome = '{1}'
                                     sobrenome = '{2}',
                                     dataniver = '{3}',                                      
                               where id = '{0}'";

                query = string.Format(query, _user.id,
                                                 _user.name,
                                                 _user.flag,
                                                 _user.keyGroup.ToString("yyyy-MM-dd"));

                retorno = conexao.ExecutarComando(query, false);
            }
            catch (Exception ex)
            {

                conexao.Error = ex.Message;
            }

            return retorno;


        }
        #endregion

        //Details BY ID
        public Team BuscarUsuario(int id)
        {
            //CONECTA, QUERY, COMANDO
            Conectar();
            string query = "select * from amigos where id = '{0}'";
            query = string.Format(query, id);
            conexao.ExecutarComando(query, true);


            //MAPEAMENTO
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

            return ListaRetorno.First();

        }

        //DETAILS BY NAME
        public List<Team> BuscaParteNome(string busca)
        {
            //
            Conectar();
            string query = "select * from amigos where nome like '%{0}%' ";
            query = string.Format(query, busca);
            conexao.ExecutarComando(query, true);


            //MAPEAMENTO
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

        //DETAILS BY ANIVER
        public List<Team> BuscaAniversariante(DateTime niver)
        {
            //
            Conectar();
            string query = $"select * from amigos where dataniver = {niver.DayOfYear}";
            query = string.Format(query, niver);
            conexao.ExecutarComando(query, true);


            //MAPEAMENTO
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

    }
}