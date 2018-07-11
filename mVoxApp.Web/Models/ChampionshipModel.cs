using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{    
    public class TeamModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50)]
        public string Name { get; set; }

        //Caso torneio comece por Pontos
        [Required(ErrorMessage = "Informe o número do Grupo")]
        [Display(Name = "Chave do Grupo")]
        public int KeyGroup { get; set; }

        public bool Winner { get; set; }
    }

    public class MatchModel
    {
        public int Id { get; set; }
        public string TeamA { get; set; }
        public int GoalsTeamA { get; set; }
        public string TeamB { get; set; }
        public int GoalsTeamB { get; set; }
    }

    public class KeyGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxMatchs { get; set; }
        public int TotalMatchs { get; set; }
        List<MatchModel> ListMatchs { get; set; }
    }

    //public class ChampionshipModel
    //{
    //    public int Id { get; set; }
    //    public List<KeyGroupModel> ListKeyGroups { get; set; }

    //    public ChampionshipModel()
    //    {
    //        ListKeyGroups = new List<KeyGroupModel>();
    //    }
    //}
}