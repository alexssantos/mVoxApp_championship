using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace mVoxApp.Web.App_Data.Repository
{
    public class StaticListRepository
    {   
        static List<KeyGroupModel>  StaticListGroups;
        static List<MatchModel>     StaticListMatch;
        static List<TeamModel>      StaticListTeams;

        Repository _repy = new Repository();

        public StaticListRepository()
        {
            if (StaticListTeams == null)
            {
                StaticListTeams = new List<TeamModel>();
                StaticListTeams = _repy.

            }
            if (StaticListGroups == null)
            {
                StaticListGroups = new List<KeyGroupModel>();
            }
            if (StaticListMatch == null)
            {
                StaticListMatch = new List<MatchModel>();
            }

        }
    }
}