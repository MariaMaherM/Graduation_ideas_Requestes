using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA_Project.ViewModel
{
    public class TeamLeaderViewModel
    {
        public IEnumerable<Professor> Professosrs { get; set; }
        public TeamLeader TeamLeaders { get; set; }
        public Professor pf { get; set; }
    }
}