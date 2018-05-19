using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IA_Project.Models
{
    public class TeamLeaderModel
    {
        public int id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public Nullable<int> Professor_id { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public Nullable<decimal> Phone_Number { get; set; }
        public Nullable<int> level { get; set; }
        public string Skills { get; set; }
        public Nullable<int> idea_project_id { get; set; }

    }
}