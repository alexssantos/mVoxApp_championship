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
        DB_Repository _rep;

        public List<TeamModel> GetAll()
        {
            _rep = new DB_Repository();
            List<TeamModel> _retorno = _rep.GetTeams();
            _retorno = _retorno.OrderBy(x => x.Name).ToList();

            return _retorno;
        }

        public TeamModel GetByID(int id)
        {
            _rep = new DB_Repository();
            TeamModel _retorno = _rep.GetTeamByID(id);

            return _retorno;
        }

        public List<TeamModel> GetByName(string teamName)
        {
            _rep = new DB_Repository();
            List<TeamModel> _retorno = _rep.GetTeamBySTRING(teamName);

            return _retorno;
        }

        public bool Create(TeamModel team)
        {
            _rep = new DB_Repository();
            bool retornoCreate = _rep.CreateTeam_DB(team);

            return retornoCreate;
        }

        public bool Update(TeamModel _team)
        {
            _rep = new DB_Repository();
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
            _rep = new DB_Repository();
            bool retorno = _rep.DeleteTeam_DB(id);
            return retorno;
        }
    }
    #endregion

    #region DB KeyGroup
    public class ManagerKeygroupRepository
    {
        DB_Repository _rep;

        public List<KeyGroupModel> GetAll()
        {
            _rep = new DB_Repository();
            List<KeyGroupModel> ListaTodos = _rep.GetKeyGroups();
            List<KeyGroupModel> _returo = ListaTodos.OrderBy(x => x.Name).ToList();

            return _returo;
        }

        //public bool KeyGroupFull(int id)
        //{
        //    _rep = new DB_Repository();
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

    public class ManagerTeamStaticRepository
    {
        StaticListRepository _rep = new StaticListRepository();

        //----------STATIC CRUD TEAM ----------//
        public List<TeamModel> GetAll()
        {
            List<TeamModel> _retorno = _rep.GetAllTeam();
            _retorno = _retorno.OrderBy(x => x.Name).ToList();

            return _retorno;
        }

        public TeamModel GetByID(int id)
        {
            TeamModel _retorno = _rep.GetTeamByID(id);

            return _retorno;
        }

        public List<TeamModel> GetByName(string teamName)
        {
            List<TeamModel> _retorno = _rep.GetTeamByNAME(teamName);

            return _retorno;
        }

        public void Create(TeamModel team)
        {
            _rep.CreateTeam(team);
        }

        public void Update(TeamModel _team)
        {
            _rep.UpdateTeam(_team);
        }

        public void Delete(int id)
        {
            _rep.DeleteTeam(id);
        }

        public int CountByKeyGroup(int idKeyGroup)
        {
            List<TeamModel> all = GetAll();
            int count = all.Where(x => x.KeyGroup == idKeyGroup).Count();
            return count;
        }
    }

    public class ManagerKeyGroupStaticRepository
    {
        StaticListRepository _rep;

        public List<KeyGroupModel> GetAll()
        {
            _rep = new StaticListRepository();
            List<KeyGroupModel> ListaTodos = _rep.GetKeyGroups();
            List<KeyGroupModel> _returo = ListaTodos.OrderBy(x => x.Name).ToList();

            return _returo;
        }

        public bool KeyGroupFull(int id)
        {
            _rep = new StaticListRepository();
            KeyGroupModel _kGroup = _rep.GetKeyGroupByID(id);
            if (_kGroup.MaxTeams > _kGroup.TotalTeams)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}