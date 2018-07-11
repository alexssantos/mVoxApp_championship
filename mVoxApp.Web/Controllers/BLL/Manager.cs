using mVoxApp.Web.App_Data.Repository;
using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Controllers.BLL
{

    #region DB Team
    public class ManagerTeamRepository
    {
        Repository _rep;        

        public List<TeamModel> GetAll()
        {
            _rep = new Repository();
            List<TeamModel> _retorno = _rep.GetTeams();
            _retorno = _retorno.OrderBy(x => x.Name).ToList();

            return _retorno;
        }

        public TeamModel GetByID(int id)
        {
            _rep = new Repository();
            TeamModel _retorno = _rep.GetTeamByID(id);

            return _retorno;
        }

        public List<TeamModel> GetByName(string teamName)
        {
            _rep = new Repository();
            List<TeamModel> _retorno = _rep.GetTeamBySTRING(teamName);

            return _retorno;
        }                

        public bool Create(TeamModel team)
        {
            _rep = new Repository();
            bool retornoCreate = _rep.CreateTeam_DB(team);

            return retornoCreate;
        }

        public bool Update(TeamModel _team)
        {
            _rep = new Repository();
            bool retornoDel = _rep.DeleteTeam_DB(_team.Id);
            bool retornoAdd = _rep.CreateTeam_DB(_team);

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
            bool retorno = _rep.DeleteTeam_DB(id);
            return retorno;
        }
    }
    #endregion

    #region DB KeyGroup
    public class ManagerKeygroupRepository
    {
        Repository _rep;

        public List<KeyGroupModel> GetAll()
        {
            _rep = new Repository();
            List<KeyGroupModel> ListaTodos = _rep.GetKeyGroups();
            List<KeyGroupModel> _returo = ListaTodos.OrderBy(x => x.Name).ToList();

            return _returo;
        }

        //public bool KeyGroupFull(int id)
        //{
        //    _rep = new Repository();
        //    KeyGroupModel _kGroup = _rep.GetKeyGroupByID(id);
        //    if (_kGroup.MaxTeams > _kGroup.TotalTeams)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public int KeyGroupTeamCounter()
        {
            int count = 0;

            return count;

        }
    }
    #endregion

    public class ManagerStaticRepository
    {
        StaticListRepository _staticRep;


        //----------STATIC CRUD TEAM ----------//
        public List<TeamModel> GetAllTeam()
        {

        }
    }


}