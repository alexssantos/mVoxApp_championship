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

        public void Create(Team team)
        {
            _rep = new Repository();
            _rep.Create_DB(team);            
        }


    }
}