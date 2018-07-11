using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mVoxApp.Web.Models
{
    public class KeyGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxMatchs { get; set; }
        public int TotalMatchs { get; set; }
        List<MatchModel> ListMatchs { get; set; }
    }    
}