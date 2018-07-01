using mVoxApp.Web.App_Data.Repository;
using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Controllers.BLL
{
    public class Manager
    {
        Repository _rep;

        public List<Team> GetAll()
        {
            _rep = new Repository();
            List<Team> ListaTodos = _rep.GetTeams();
            List<Team> _returo = ListaTodos.OrderBy(x => x.name).ToList();

            return _returo;
        }
                

        public bool Create(Team team)
        {
            _rep = new Repository();
            bool retornoCreate = _rep.Create_DB(team);

            return retornoCreate;
        }

        public bool Update(Team _team)
        {
            _rep = new Repository();
            bool retornoDel = _rep.Delete_DB(_team.id);
            bool retornoAdd = _rep.Create_DB(_team);

            if (retornoAdd == retornoDel == true)
            {
                return retornoAdd;
            }
            else
            {                
                return false;
            }
        }

        public bool Deletar_Usuario(int id)
        {
            bool retorno = _rep.Delete_DB(id);
            return retorno;
        }

    }
}