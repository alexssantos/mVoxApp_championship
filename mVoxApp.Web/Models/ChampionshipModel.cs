using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class ChampionshipModel
    {
        public int Id { get; set; }
        public List<KeyGroupModel> ListKeyGroups { get; set; }

        public ChampionshipModel()
        {
            ListKeyGroups = new List<KeyGroupModel>();
        }
    }
}