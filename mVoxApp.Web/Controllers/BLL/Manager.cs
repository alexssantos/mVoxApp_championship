using mVoxApp.Web.App_Data.Repository;
using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Controllers.BLL
{
        
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