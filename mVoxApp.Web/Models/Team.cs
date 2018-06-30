using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int keyGroup { get; set; }
        public string flag { get; set; }
    }
}