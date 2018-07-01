using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class KeyGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxTeams { get; set; }
        public int totalTeams { get; set; }
        List<Team> ListTeam { get; set; }
    }

    public class KeyGroupViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxTeams { get; set; }
        public int totalTeams { get; set; }

    }



}