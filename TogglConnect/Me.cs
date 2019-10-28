using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglConnect
{
    public class UserData
    {
        public int id { get; set; }
        public string api_token { get; set; }
        public int default_wid { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string jquery_timeofday_format { get; set; }
        public string jquery_date_format { get; set; }
        public string timeofday_format { get; set; }
        public string date_format { get; set; }
        public bool store_start_and_stop_time { get; set; }
        public int beginning_of_week { get; set; }
        public string language { get; set; }
        public string duration_format { get; set; }
        public string image_url { get; set; }
        public DateTime at { get; set; }
        public DateTime created_at { get; set; }
        public string timezone { get; set; }
        public int retention { get; set; }
        public List<Project> projects { get; set; }
        //public List<Tag> tags { get; set; }
        //public List<Task> tasks { get; set; }
        //public List<Workspace> workspaces { get; set; }
        public List<Client> clients { get; set; }
    }
    public class User
    {
        public int since { get; set; }
        public UserData data { get; set; }
    }
}
