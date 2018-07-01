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

        public Team GetByID(int id)
        {
            _rep = new Repository();
            Team _retorno = _rep.GetByID(id);

            return _retorno;
        }

        public List<Team> GetByName(string teamName)
        {
            _rep = new Repository();
            List<Team> _retorno = _rep.GetBySTRING(teamName);

            return _retorno;
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

        public bool Delete(int id)
        {
            _rep = new Repository();
            bool retorno = _rep.Delete_DB(id);
            return retorno;
        }

    }
}