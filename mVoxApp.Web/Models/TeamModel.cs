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

        [Display(Name = "Pontos")]
        public int Points { get; set; }

        //Caso torneio comece por Pontos
        [Required(ErrorMessage = "Informe o número do Grupo")]
        [Display(Name = "Chave do Grupo")]
        public int KeyGroup { get; set; }

        public string Flag { get; set; }                
    }
}