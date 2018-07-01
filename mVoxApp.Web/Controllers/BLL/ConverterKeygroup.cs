using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Controllers.BLL
{
    public class ConverterKeygroup
    {

        public KeyGroupViewModel ToViewModel(KeyGroup item)
        {
            KeyGroupViewModel model = new KeyGroupViewModel();
            model.name = item.name;
            model.id = item.id;
            model.maxTeams = item.maxTeams;
            model.totalTeams = item.totalTeams;

            return model;
        }

        public KeyGroup ToNormal(KeyGroupViewModel model)
        {
            KeyGroup item = new KeyGroup();
            item.name = model.name;
            item.id = model.id;
            item.maxTeams = model.maxTeams;
            item.totalTeams = model.totalTeams;

            return item;
        }

    }
}