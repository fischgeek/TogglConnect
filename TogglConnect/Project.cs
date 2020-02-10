using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglConnect
{
    public class ProjectData
    {
        public Project data { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public int wid { get; set; }
        public int cid { get; set; }
        public int pid { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        //public List<string> keywords { get; set; }
    }
}
