using IA_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA_Project.ViewModel
{
    public class ProfessorTeamLeader
    {

        public Professor Professors { get; set; }
        public IEnumerable<TeamLeader> TeamLeaders { get; set; }


    }
}