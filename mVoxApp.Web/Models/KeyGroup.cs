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
        List<Team> TeamFrom { get; set; }
    }
}