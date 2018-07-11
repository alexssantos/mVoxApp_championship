using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class MatchModel
    {
        public int      Id { get; set; }
        public string   TeamA { get; set; }
        public int      GoalsTeamA { get; set; }
        public string   TeamB { get; set; }
        public int      GoalsTeamB { get; set; }
    }
}