using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Controllers.BLL
{
    public class ConverterTeam
    {

        public TeamViewModel ToViewModel(Team item)
        {
            TeamViewModel model = new TeamViewModel();
            model.name = item.name;
            model.id = item.id;
            model.points = item.points;
            model.flag = item.flag;
            model.keyGroup = item.keyGroup;

            return model;
        }

        public Team ToNormal(TeamViewModel model)
        {
            Team item = new Team();
            item.name = model.name;
            item.id = model.id;
            item.points = model.points;
            item.flag= model.flag;
            item.keyGroup = model.keyGroup;

            return item;
        }

    }
}