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
        static List<TeamModel>      StaticListTeams;
        static List<KeyGroupModel>  StaticListGroups;
        static List<MatchModel>     StaticListMatch;

        public StaticListRepository()
        {
            if (StaticListTeams == null)
            {
                StaticListTeams = new List<TeamModel>();
                PreLoadTeams();
            }
            if (StaticListGroups == null)
            {
                StaticListGroups = new List<KeyGroupModel>();
                PreLoadKeyGroups();
            }
            if (StaticListMatch == null)
            {
                StaticListMatch = new List<MatchModel>();
            }
        }


        private void PreLoadTeams()
        {
            //Oitava, pelo menos, 16 times
            for (int i = 0; i < 16; i++)
            {
                StaticListTeams.Add(
                    new TeamModel { Id=i,
                                    Name= $"Time {i}",
                                    KeyGroup= 0,
                                    Winner= false
                    }
                );
            }
        }

        /// <KEYGroups>        
        /// 0. Nenhum
        /// 1. Oitavas
        /// 2. Quartas
        /// 3. Semi
        /// 4. Finais
        /// 
        /// </KEYGroups>
        private void PreLoadKeyGroups()
        {
            List<string> namesKeyGroups = new List<string>();
            namesKeyGroups.Add("Não Qualificado"); 
            namesKeyGroups.Add("Oitavas de Finais"); 
            namesKeyGroups.Add("Quartas de Finais"); 
            namesKeyGroups.Add("Quartas de Finais"); 
            namesKeyGroups.Add("Final"); 

            for (int i = 0; i < 5; i++)
            {
                StaticListGroups.Add(new KeyGroupModel { Id=i,
                                                         Name = namesKeyGroups[i],
                                                         MaxMatchs = ( 1/( 2^(i) ) ) * 32,
                                                         TotalMatchs = 0 });
            }

            StaticListGroups[0].MaxMatchs = 1000;
        }
    }
}