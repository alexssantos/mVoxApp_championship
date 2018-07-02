using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class Team
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "Pontos")]
        public int points { get; set; }

        [Required(ErrorMessage = "Informe o número do Grupo")]
        [Display(Name = "Chave do Grupo")]
        public int keyGroup { get; set; }

        public List<int> allKeyGroups{ get; set; }
        public string flag { get; set; }

        public Team()
        {
            allKeyGroups = new List<int>();
        }
    }

    public class TeamViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public int keyGroup { get; set; }
        public string flag { get; set; }
    }
}