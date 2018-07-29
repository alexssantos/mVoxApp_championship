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
        //static List<MatchModel>     StaticListMatch;
        
        //Constructor
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
        }

        //PreLOAD
        private void PreLoadTeams()
        {
            //Oitava, pelo menos, 16 times
            for (int i = 0; i < 16; i++)
            {
                StaticListTeams.Add(
                    new TeamModel { Id=i,
                                    Name= $"Time {i}",
                                    KeyGroup = 0,
                                    Winner= false
                    }
                );
            }
        }
        
        /// <KEY-Groups: Names>        
        /// 0. Nenhum
        /// 1. Oitavas
        /// 2. Quartas
        /// 3. Semi
        /// 4. Finais
        /// 
        /// </KEYGroups>
        private void PreLoadKeyGroups()
        {
            List<string> namesKeyGroups = new List<string>( )
            {
                "Não Qualificado (oo)",
                "Oitavas de Finais (16)",
                "Quartas de Finais (8)",
                "Semi Finais (4)",
                "Final (2)"
            };

            for (int i = 0; i < namesKeyGroups.Count; i++)
            {
                var maxTeams = (int)((1 / (Math.Pow(2, i))) * 32);      //Lista não aceita fazer calculo junto com a adição de parametros
                StaticListGroups.Add(new KeyGroupModel { Id=i,
                                                         Name = namesKeyGroups[i],
                                                         MaxTeams = maxTeams,
                                                         TotalTeams = 0 });
            }       

            //Não Classificados sem limites em qtdd de times
            StaticListGroups[0].MaxTeams = 1000;     
        }

        //CRUD Team
        public List<TeamModel> GetAllTeam()
        {
            return StaticListTeams;
        }

        public TeamModel GetTeamByID(int myId)
        {
            return StaticListTeams.Where(x => x.Id == myId).First();
        }

        public List<TeamModel> GetTeamByNAME(string myName)
        {
            return StaticListTeams.FindAll(x => x.Name.Contains(myName));
        }

        public void CreateTeam(TeamModel newTeam)
        {
            newTeam.Id = StaticListTeams.Last().Id + 1;
            StaticListTeams.Add(newTeam);
        }

        public void DeleteTeam(int myId)
        {
            var ToDelete = GetTeamByID(myId);
            StaticListTeams.Remove(ToDelete);
        }

        public void UpdateTeam(TeamModel newTeam)
        {
            var oldTeam = GetTeamByID(newTeam.Id);
            var index = StaticListTeams.IndexOf(oldTeam);
            StaticListTeams[index] = newTeam;
        }

        //KeyGroups
        public List<KeyGroupModel> GetKeyGroups()
        {
            return StaticListGroups;
        }

        public KeyGroupModel GetKeyGroupByID(int id)
        {
            var retorno = StaticListGroups.Where(x => x.Id == id).First();
            return retorno;

        }
    }
}